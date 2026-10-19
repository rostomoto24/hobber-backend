namespace Hobber.Application.Contracts;

/// <summary><paramref name="ParentId"/> is null for a top-level category; leaves carry their parent's id.</summary>
public sealed record CategoryDto(Guid Id, string Name, string Accent, int DisplayOrder, Guid? ParentId);

public sealed record UserDto(
    Guid Id,
    string Email,
    string? Phone,
    string? FirstName,
    string? LastName,
    string DisplayName,
    string? AvatarUrl,
    string ProfileType,
    IReadOnlyList<CategoryDto> Interests);

/// <summary><paramref name="IsNewUser"/> is true when a social sign-in just created the account (route Students to Interests).</summary>
public sealed record AuthResponse(
    UserDto User,
    string AccessToken,
    DateTime AccessTokenExpiresAt,
    string RefreshToken,
    DateTime RefreshTokenExpiresAt,
    bool IsNewUser = false);

/// <summary>What a course card on Home shows: image, title, tutor, enrolled/capacity.</summary>
public sealed record CourseSummaryDto(
    Guid Id,
    string Title,
    string? ImageUrl,
    Guid TutorId,
    string TutorName,
    CategoryDto Category,
    string Format,
    string Level,
    decimal Price,
    int EnrolledCount,
    int Capacity,
    DateTime? NextSessionAt);

public sealed record CourseSessionDto(Guid Id, DateTime StartsAt, DateTime EndsAt);

public sealed record CourseDetailsDto(
    Guid Id,
    string Title,
    string? Description,
    string? ImageUrl,
    Guid TutorId,
    string TutorName,
    string? TutorAvatarUrl,
    CategoryDto Category,
    string Format,
    string Level,
    string? Location,
    decimal Price,
    int EnrolledCount,
    int Capacity,
    IReadOnlyList<CourseSessionDto> Sessions,
    bool IsEnrolled,
    bool CanEnroll);

public sealed record TutorSummaryDto(Guid Id, string Name, string? AvatarUrl, int CourseCount);

public sealed record SearchResultDto(IReadOnlyList<CourseSummaryDto> Courses, IReadOnlyList<TutorSummaryDto> Tutors);

public sealed record UnreadCountDto(int Count);
