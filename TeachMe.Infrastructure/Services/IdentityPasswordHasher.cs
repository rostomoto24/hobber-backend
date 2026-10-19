using Microsoft.AspNetCore.Identity;
using TeachMe.Application.Abstractions;
using TeachMe.Domain.Entities;

namespace TeachMe.Infrastructure.Services;

/// <summary>PBKDF2 via ASP.NET Core Identity's hasher (D4: own identity, no hosted provider).</summary>
public sealed class IdentityPasswordHasher : IPasswordHasher
{
    private static readonly PasswordHasher<User> Hasher = new();
    private static readonly User Dummy = new();

    public string Hash(string password) => Hasher.HashPassword(Dummy, password);

    public bool Verify(string hash, string password) =>
        Hasher.VerifyHashedPassword(Dummy, hash, password) is not PasswordVerificationResult.Failed;
}
