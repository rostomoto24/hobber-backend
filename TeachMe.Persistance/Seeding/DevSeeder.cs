using Microsoft.EntityFrameworkCore;
using TeachMe.Application.Abstractions;
using TeachMe.Domain.Entities;
using TeachMe.Domain.Enums;
using TeachMe.Persistance.Contexts;

namespace TeachMe.Persistance.Seeding;

/// <summary>
/// Development data so the Home screen has something to show: the categories from the designs,
/// three tutors, a demo student ("Salome", as in the mock-up), courses in every Home section.
/// Idempotent: does nothing when categories already exist. Also used by the integration tests.
/// </summary>
public static class DevSeeder
{
    public const string DemoPassword = "Hobber123";
    public const string DemoStudentEmail = "salome@hobber.dev";
    public const string DemoTutorEmail = "ana@hobber.dev";

    public static async Task SeedAsync(TeachMeDbContext db, IPasswordHasher hasher, DateTime now, CancellationToken cancellationToken = default)
    {
        if (await db.Categories.AnyAsync(cancellationToken))
        {
            return;
        }

        var categories = new (string Name, Accent Accent)[]
        {
            ("Pilates", Accent.Coral),
            ("Leather crafts", Accent.Yellow),
            ("Drawing and painting", Accent.Green),
            ("Knitting", Accent.Blue),
            ("Ceramic", Accent.Coral),
            ("Cooking", Accent.Green),
            ("Padel", Accent.Yellow),
            ("Photography", Accent.Blue),
        }
        .Select((c, i) => new Category { Id = Guid.NewGuid(), Name = c.Name, Accent = c.Accent, DisplayOrder = i + 1 })
        .ToList();
        db.Categories.AddRange(categories);
        Category Cat(string name) => categories.First(c => c.Name == name);

        var hash = hasher.Hash(DemoPassword);
        User MakeUser(string email, string first, string last, ProfileType type, string? avatar = null) => new()
        {
            Id = Guid.NewGuid(),
            Email = email,
            Phone = "+995 555 000 000",
            PasswordHash = hash,
            FirstName = first,
            LastName = last,
            AvatarUrl = avatar,
            ProfileType = type,
            AcceptedTermsAt = now,
            CreatedAt = now.AddDays(-60),
        };

        var ana = MakeUser(DemoTutorEmail, "Ana", "Sarajishvili", ProfileType.Tutor);
        var mariamJ = MakeUser("mariam.j@hobber.dev", "Mariam", "Jabashvili", ProfileType.Tutor);
        var mariamP = MakeUser("mariam.p@hobber.dev", "Mariam", "Parulava", ProfileType.Tutor);
        var salome = MakeUser(DemoStudentEmail, "Salome", "Beridze", ProfileType.Student, "https://i.pravatar.cc/96?img=47");
        var extraStudents = Enumerable.Range(1, 150)
            .Select(i => MakeUser($"student{i}@hobber.dev", $"Student{i}", "Demo", ProfileType.Student))
            .ToList();
        db.Users.AddRange(ana, mariamJ, mariamP, salome);
        db.Users.AddRange(extraStudents);

        db.UserInterests.AddRange(
            new UserInterest { UserId = salome.Id, CategoryId = Cat("Knitting").Id },
            new UserInterest { UserId = salome.Id, CategoryId = Cat("Pilates").Id },
            new UserInterest { UserId = salome.Id, CategoryId = Cat("Drawing and painting").Id });

        Course MakeCourse(string title, User tutor, Category category, int capacity, CourseFormat format, decimal price, int daysUntilFirstSession, string image, int ageDays) => new()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = $"{title}: a friendly course for anyone curious about {category.Name.ToLowerInvariant()}. Materials included.",
            TutorId = tutor.Id,
            CategoryId = category.Id,
            Format = format,
            Location = format == CourseFormat.Offline ? "Tbilisi, Vake" : null,
            Price = price,
            Capacity = capacity,
            ImageUrl = image,
            CreatedAt = now.AddDays(-ageDays),
            Sessions = Enumerable.Range(0, 4).Select(w => new CourseSession
            {
                Id = Guid.NewGuid(),
                StartsAt = now.Date.AddDays(daysUntilFirstSession + 7 * w).AddHours(18),
                EndsAt = now.Date.AddDays(daysUntilFirstSession + 7 * w).AddHours(19).AddMinutes(30),
            }).ToList(),
        };

        var courses = new[]
        {
            // "For you" (Salome's interests: Knitting, Pilates, Drawing and painting)
            MakeCourse("Knitting for beginners", ana, Cat("Knitting"), 20, CourseFormat.Offline, 0, 14, "https://images.unsplash.com/photo-1584992236310-6edddc08acff?w=600", 3),
            MakeCourse("Pilates 101", mariamJ, Cat("Pilates"), 150, CourseFormat.Online, 0, 21, "https://images.unsplash.com/photo-1518611012118-696072aa579a?w=600", 5),
            MakeCourse("Watercolour basics", ana, Cat("Drawing and painting"), 15, CourseFormat.Offline, 25, 10, "https://images.unsplash.com/photo-1513364776144-60967b0f800f?w=600", 2),
            // "Last call": 19/20 and starting in 3 days
            MakeCourse("Pilates for beginners", mariamP, Cat("Pilates"), 20, CourseFormat.Offline, 0, 3, "https://images.unsplash.com/photo-1571019614242-c5c5dee9f50b?w=600", 20),
            MakeCourse("Padel for beginners", mariamP, Cat("Padel"), 150, CourseFormat.Offline, 10, 2, "https://images.unsplash.com/photo-1554068865-24cecd4e34b8?w=600", 25),
            // "Popular"
            MakeCourse("Cooking - Advanced", mariamJ, Cat("Cooking"), 20, CourseFormat.Offline, 40, 30, "https://images.unsplash.com/photo-1556910103-1c02745aae4d?w=600", 40),
            MakeCourse("Leather wallet workshop", ana, Cat("Leather crafts"), 12, CourseFormat.Offline, 35, 18, "https://images.unsplash.com/photo-1473188588951-666fce8e7c68?w=600", 12),
            MakeCourse("Ceramic bowls", mariamJ, Cat("Ceramic"), 10, CourseFormat.Offline, 30, 25, "https://images.unsplash.com/photo-1565193566173-7a0ee3dbe261?w=600", 8),
            MakeCourse("Street photography walk", mariamP, Cat("Photography"), 25, CourseFormat.Offline, 15, 40, "https://images.unsplash.com/photo-1452587925148-ce544e77e70d?w=600", 1),
        };
        db.Courses.AddRange(courses);
        Course C(string title) => courses.First(c => c.Title == title);

        void Enroll(Course course, int count)
        {
            foreach (var student in extraStudents.Take(count))
            {
                db.Enrollments.Add(new Enrollment { Id = Guid.NewGuid(), CourseId = course.Id, StudentId = student.Id, CreatedAt = now.AddDays(-1) });
            }
        }

        Enroll(C("Knitting for beginners"), 5);
        Enroll(C("Pilates 101"), 110);
        Enroll(C("Watercolour basics"), 4);
        Enroll(C("Pilates for beginners"), 19);
        Enroll(C("Padel for beginners"), 110);
        Enroll(C("Cooking - Advanced"), 19);
        Enroll(C("Leather wallet workshop"), 7);
        Enroll(C("Ceramic bowls"), 3);

        db.Notifications.Add(new Notification
        {
            Id = Guid.NewGuid(),
            UserId = salome.Id,
            Title = "Welcome to Hobber",
            Body = "Pick your interests to get recommendations.",
            CreatedAt = now.AddDays(-1),
        });

        await db.SaveChangesAsync(cancellationToken);
    }
}
