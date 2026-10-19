using Hobber.Domain.Entities;
using Hobber.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Hobber.Persistance.Seeding;

/// <summary>
/// Reference and demo data applied through EF Core <c>HasData</c>, so it lives in the migrations and
/// exists after <c>dotnet ef database update</c> in every environment (and after <c>EnsureCreated</c>
/// in the integration tests). Every id and date is fixed on purpose: HasData diffs rows by key.
///
/// Content mirrors the Home mock-up: the categories from the designs, three tutors, the demo student
/// "Salome" with three interests, nine courses with weekly sessions (Nov 2026 to Mar 2027) and enough
/// enrolments to make "Last call" and "Popular" meaningful.
/// </summary>
public static class SeedData
{
    public const string DemoPassword = "Hobber123";
    public const string DemoStudentEmail = "salome@hobber.dev";
    public const string DemoTutorEmail = "ana@hobber.dev";
    public const int FillerStudentCount = 20;

    /// <summary>PBKDF2 hash of <see cref="DemoPassword"/> produced by ASP.NET Core Identity's PasswordHasher (v3).</summary>
    private const string DemoPasswordHash = "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==";

    private static readonly DateTime SeedDate = new(2026, 10, 20, 12, 0, 0, DateTimeKind.Utc);

    public static Guid CategoryId(int n) => new($"10000000-0000-0000-0000-{n:D12}");
    public static Guid UserId(int n) => new($"20000000-0000-0000-0000-{n:D12}");
    public static Guid CourseId(int n) => new($"30000000-0000-0000-0000-{n:D12}");
    public static Guid SessionId(int course, int week) => new($"40000000-0000-0000-{course:D4}-{week:D12}");
    public static Guid EnrollmentId(int course, int student) => new($"50000000-0000-0000-{course:D4}-{student:D12}");
    public static Guid FillerStudentId(int n) => UserId(100 + n);
    public static string FillerStudentEmail(int n) => $"student{n}@hobber.dev";

    public static readonly Guid AnaId = UserId(1);
    public static readonly Guid MariamJabashviliId = UserId(2);
    public static readonly Guid MariamParulavaId = UserId(3);
    public static readonly Guid SalomeId = UserId(4);

    private static readonly (int Id, string Name, Accent Accent)[] CategoryRows =
    [
        (1, "Pilates", Accent.Coral),
        (2, "Leather crafts", Accent.Yellow),
        (3, "Drawing and painting", Accent.Green),
        (4, "Knitting", Accent.Blue),
        (5, "Ceramic", Accent.Coral),
        (6, "Cooking", Accent.Green),
        (7, "Padel", Accent.Yellow),
        (8, "Photography", Accent.Blue),
    ];

    private sealed record CourseRow(
        int Id,
        string Title,
        Guid TutorId,
        int CategoryId,
        int Capacity,
        int Enrolled,
        CourseFormat Format,
        decimal Price,
        DateTime FirstSession,
        string Image,
        DateTime CreatedAt);

    private static readonly CourseRow[] CourseRows =
    [
        new(1, "Knitting for beginners", AnaId, 4, 20, 5, CourseFormat.Offline, 0m, new(2026, 11, 16, 18, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1584992236310-6edddc08acff?w=600", new(2026, 10, 30, 9, 0, 0, DateTimeKind.Utc)),
        new(2, "Pilates 101", MariamJabashviliId, 1, 15, 14, CourseFormat.Online, 0m, new(2026, 11, 23, 18, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1518611012118-696072aa579a?w=600", new(2026, 10, 28, 9, 0, 0, DateTimeKind.Utc)),
        new(3, "Watercolour basics", AnaId, 3, 15, 4, CourseFormat.Offline, 25m, new(2026, 11, 12, 18, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1513364776144-60967b0f800f?w=600", new(2026, 10, 31, 9, 0, 0, DateTimeKind.Utc)),
        new(4, "Pilates for beginners", MariamParulavaId, 1, 20, 19, CourseFormat.Offline, 0m, new(2026, 11, 5, 18, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1571019614242-c5c5dee9f50b?w=600", new(2026, 10, 13, 9, 0, 0, DateTimeKind.Utc)),
        new(5, "Padel for beginners", MariamParulavaId, 7, 12, 11, CourseFormat.Offline, 10m, new(2026, 11, 4, 18, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1554068865-24cecd4e34b8?w=600", new(2026, 10, 8, 9, 0, 0, DateTimeKind.Utc)),
        new(6, "Cooking - Advanced", MariamJabashviliId, 6, 20, 19, CourseFormat.Offline, 40m, new(2026, 12, 2, 18, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1556910103-1c02745aae4d?w=600", new(2026, 9, 23, 9, 0, 0, DateTimeKind.Utc)),
        new(7, "Leather wallet workshop", AnaId, 2, 12, 7, CourseFormat.Offline, 35m, new(2026, 11, 20, 18, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1473188588951-666fce8e7c68?w=600", new(2026, 10, 21, 9, 0, 0, DateTimeKind.Utc)),
        new(8, "Ceramic bowls", MariamJabashviliId, 5, 10, 3, CourseFormat.Offline, 30m, new(2026, 11, 27, 18, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1565193566173-7a0ee3dbe261?w=600", new(2026, 10, 25, 9, 0, 0, DateTimeKind.Utc)),
        new(9, "Street photography walk", MariamParulavaId, 8, 25, 0, CourseFormat.Offline, 15m, new(2027, 1, 11, 18, 0, 0, DateTimeKind.Utc), "https://images.unsplash.com/photo-1452587925148-ce544e77e70d?w=600", new(2026, 11, 1, 9, 0, 0, DateTimeKind.Utc)),
    ];

    public static void Apply(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(CategoryRows.Select(c => new Category
        {
            Id = CategoryId(c.Id),
            Name = c.Name,
            Accent = c.Accent,
            DisplayOrder = c.Id,
        }));

        var users = new List<User>
        {
            Person(AnaId, DemoTutorEmail, "Ana", "Sarajishvili", ProfileType.Tutor),
            Person(MariamJabashviliId, "mariam.j@hobber.dev", "Mariam", "Jabashvili", ProfileType.Tutor),
            Person(MariamParulavaId, "mariam.p@hobber.dev", "Mariam", "Parulava", ProfileType.Tutor),
            Person(SalomeId, DemoStudentEmail, "Salome", "Beridze", ProfileType.Student, "https://i.pravatar.cc/96?img=47"),
        };
        users.AddRange(Enumerable.Range(1, FillerStudentCount)
            .Select(n => Person(FillerStudentId(n), FillerStudentEmail(n), $"Student{n}", "Demo", ProfileType.Student)));
        modelBuilder.Entity<User>().HasData(users);

        modelBuilder.Entity<UserInterest>().HasData(
            new { UserId = SalomeId, CategoryId = CategoryId(4) },
            new { UserId = SalomeId, CategoryId = CategoryId(1) },
            new { UserId = SalomeId, CategoryId = CategoryId(3) });

        modelBuilder.Entity<Course>().HasData(CourseRows.Select(c => new Course
        {
            Id = CourseId(c.Id),
            Title = c.Title,
            Description = $"{c.Title}: a friendly course for anyone curious about {CategoryRows[c.CategoryId - 1].Name.ToLowerInvariant()}. Materials included.",
            TutorId = c.TutorId,
            CategoryId = CategoryId(c.CategoryId),
            Format = c.Format,
            Location = c.Format == CourseFormat.Offline ? "Tbilisi, Vake" : null,
            Price = c.Price,
            Capacity = c.Capacity,
            ImageUrl = c.Image,
            CreatedAt = c.CreatedAt,
        }));

        modelBuilder.Entity<CourseSession>().HasData(CourseRows.SelectMany(c =>
            Enumerable.Range(0, 12).Select(week => new CourseSession
            {
                Id = SessionId(c.Id, week + 1),
                CourseId = CourseId(c.Id),
                StartsAt = c.FirstSession.AddDays(7 * week),
                EndsAt = c.FirstSession.AddDays(7 * week).AddMinutes(90),
            })));

        modelBuilder.Entity<Enrollment>().HasData(CourseRows.SelectMany(c =>
            Enumerable.Range(1, c.Enrolled).Select(n => new Enrollment
            {
                Id = EnrollmentId(c.Id, n),
                CourseId = CourseId(c.Id),
                StudentId = FillerStudentId(n),
                CreatedAt = SeedDate,
            })));

        modelBuilder.Entity<Notification>().HasData(new Notification
        {
            Id = new Guid("60000000-0000-0000-0000-000000000001"),
            UserId = SalomeId,
            Title = "Welcome to Hobber",
            Body = "Pick your interests to get recommendations.",
            CreatedAt = SeedDate,
        });
    }

    private static User Person(Guid id, string email, string first, string last, ProfileType type, string? avatar = null) => new()
    {
        Id = id,
        Email = email,
        Phone = "+995 555 000 000",
        PasswordHash = DemoPasswordHash,
        FirstName = first,
        LastName = last,
        AvatarUrl = avatar,
        ProfileType = type,
        AcceptedTermsAt = SeedDate,
        CreatedAt = SeedDate.AddDays(-60),
    };
}
