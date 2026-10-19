using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Hobber.Application.Abstractions;
using Hobber.Application.Contracts;
using Hobber.Persistance.Contexts;
using Hobber.Persistance.Seeding;

namespace Hobber.Tests;

/// <summary>
/// Boots the real API against an in-memory SQLite database seeded with <see cref="DevSeeder"/>.
/// One database per factory instance; each test class gets its own through IClassFixture.
/// </summary>
public sealed class HobberApiFactory : WebApplicationFactory<Program>
{
    private readonly SqliteConnection _connection = new("DataSource=:memory:");

    public static readonly DateTime SeedNow = new(2026, 10, 19, 12, 0, 0, DateTimeKind.Utc);

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");
        builder.UseSetting("Database:MigrateAndSeedOnStartup", "false");

        builder.ConfigureTestServices(services =>
        {
            services.RemoveAll<DbContextOptions<HobberDbContext>>();
            services.RemoveAll<HobberDbContext>();

            _connection.Open();
            services.AddDbContext<HobberDbContext>(o => o.UseSqlite(_connection));

            using var provider = services.BuildServiceProvider();
            using var scope = provider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<HobberDbContext>();
            db.Database.EnsureCreated();
            DevSeeder.SeedAsync(db, scope.ServiceProvider.GetRequiredService<IPasswordHasher>(), SeedNow).GetAwaiter().GetResult();
        });
    }

    public async Task<HttpClient> CreateClientAsAsync(string email, string password = DevSeeder.DemoPassword)
    {
        var client = CreateClient();
        var response = await client.PostAsJsonAsync("/api/auth/login", new { email, password });
        response.EnsureSuccessStatusCode();
        var auth = (await response.Content.ReadFromJsonAsync<AuthResponse>())!;
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", auth.AccessToken);
        return client;
    }

    public HobberDbContext CreateDbContext()
    {
        var scope = Services.CreateScope();
        return scope.ServiceProvider.GetRequiredService<HobberDbContext>();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
        if (disposing)
        {
            _connection.Dispose();
        }
    }
}
