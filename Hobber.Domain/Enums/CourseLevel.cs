namespace Hobber.Domain.Enums;

/// <summary>Difficulty filter on the search page. NotApplicable covers courses without a skill ladder (walks, tastings).</summary>
public enum CourseLevel
{
    NotApplicable = 0,
    Beginner = 1,
    Advanced = 2,
    Professional = 3,
}
