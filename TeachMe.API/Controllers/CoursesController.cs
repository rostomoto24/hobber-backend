using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachMe.Domain.Entities;
using TeachMe.Persistance.Contexts;

namespace TeachMe.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CoursesController(TeachMeDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Course>>> GetCourses(CancellationToken cancellationToken)
    {
        var courses = await dbContext.Courses
            .AsNoTracking()
            .OrderByDescending(course => course.CreatedAt)
            .ToListAsync(cancellationToken);

        return Ok(courses);
    }
}
