using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hobber.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SeedDemoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Accent", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), 1, 1, "Pilates" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), 2, 2, "Leather crafts" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), 3, 3, "Drawing and painting" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), 4, 4, "Knitting" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), 1, 5, "Ceramic" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), 3, 6, "Cooking" },
                    { new Guid("10000000-0000-0000-0000-000000000007"), 2, 7, "Padel" },
                    { new Guid("10000000-0000-0000-0000-000000000008"), 4, 8, "Photography" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AcceptedTermsAt", "AvatarUrl", "CreatedAt", "Email", "FirstName", "LastName", "PasswordHash", "Phone", "ProfileType" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "ana@hobber.dev", "Ana", "Sarajishvili", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 2 },
                    { new Guid("20000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "mariam.j@hobber.dev", "Mariam", "Jabashvili", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 2 },
                    { new Guid("20000000-0000-0000-0000-000000000003"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "mariam.p@hobber.dev", "Mariam", "Parulava", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 2 },
                    { new Guid("20000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), "https://i.pravatar.cc/96?img=47", new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "salome@hobber.dev", "Salome", "Beridze", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000101"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student1@hobber.dev", "Student1", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000102"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student2@hobber.dev", "Student2", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000103"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student3@hobber.dev", "Student3", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000104"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student4@hobber.dev", "Student4", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000105"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student5@hobber.dev", "Student5", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000106"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student6@hobber.dev", "Student6", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000107"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student7@hobber.dev", "Student7", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000108"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student8@hobber.dev", "Student8", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000109"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student9@hobber.dev", "Student9", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000110"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student10@hobber.dev", "Student10", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000111"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student11@hobber.dev", "Student11", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000112"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student12@hobber.dev", "Student12", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000113"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student13@hobber.dev", "Student13", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000114"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student14@hobber.dev", "Student14", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000115"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student15@hobber.dev", "Student15", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000116"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student16@hobber.dev", "Student16", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000117"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student17@hobber.dev", "Student17", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000118"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student18@hobber.dev", "Student18", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000119"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student19@hobber.dev", "Student19", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 },
                    { new Guid("20000000-0000-0000-0000-000000000120"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, new DateTime(2026, 8, 21, 12, 0, 0, 0, DateTimeKind.Utc), "student20@hobber.dev", "Student20", "Demo", "AQAAAAIAAYagAAAAELmny6tiZnucsMEUjp6RN/IPb4RMYUUn70HlTmC1FU9U3pNSaTa4OFSSE5TEFn5SMg==", "+995 555 000 000", 1 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Capacity", "CategoryId", "CreatedAt", "Description", "Format", "ImageUrl", "Location", "Price", "Title", "TutorId" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000001"), 20, new Guid("10000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 30, 9, 0, 0, 0, DateTimeKind.Utc), "Knitting for beginners: a friendly course for anyone curious about knitting. Materials included.", 2, "https://images.unsplash.com/photo-1584992236310-6edddc08acff?w=600", "Tbilisi, Vake", 0m, "Knitting for beginners", new Guid("20000000-0000-0000-0000-000000000001") },
                    { new Guid("30000000-0000-0000-0000-000000000002"), 15, new Guid("10000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 28, 9, 0, 0, 0, DateTimeKind.Utc), "Pilates 101: a friendly course for anyone curious about pilates. Materials included.", 1, "https://images.unsplash.com/photo-1518611012118-696072aa579a?w=600", null, 0m, "Pilates 101", new Guid("20000000-0000-0000-0000-000000000002") },
                    { new Guid("30000000-0000-0000-0000-000000000003"), 15, new Guid("10000000-0000-0000-0000-000000000003"), new DateTime(2026, 10, 31, 9, 0, 0, 0, DateTimeKind.Utc), "Watercolour basics: a friendly course for anyone curious about drawing and painting. Materials included.", 2, "https://images.unsplash.com/photo-1513364776144-60967b0f800f?w=600", "Tbilisi, Vake", 25m, "Watercolour basics", new Guid("20000000-0000-0000-0000-000000000001") },
                    { new Guid("30000000-0000-0000-0000-000000000004"), 20, new Guid("10000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 13, 9, 0, 0, 0, DateTimeKind.Utc), "Pilates for beginners: a friendly course for anyone curious about pilates. Materials included.", 2, "https://images.unsplash.com/photo-1571019614242-c5c5dee9f50b?w=600", "Tbilisi, Vake", 0m, "Pilates for beginners", new Guid("20000000-0000-0000-0000-000000000003") },
                    { new Guid("30000000-0000-0000-0000-000000000005"), 12, new Guid("10000000-0000-0000-0000-000000000007"), new DateTime(2026, 10, 8, 9, 0, 0, 0, DateTimeKind.Utc), "Padel for beginners: a friendly course for anyone curious about padel. Materials included.", 2, "https://images.unsplash.com/photo-1554068865-24cecd4e34b8?w=600", "Tbilisi, Vake", 10m, "Padel for beginners", new Guid("20000000-0000-0000-0000-000000000003") },
                    { new Guid("30000000-0000-0000-0000-000000000006"), 20, new Guid("10000000-0000-0000-0000-000000000006"), new DateTime(2026, 9, 23, 9, 0, 0, 0, DateTimeKind.Utc), "Cooking - Advanced: a friendly course for anyone curious about cooking. Materials included.", 2, "https://images.unsplash.com/photo-1556910103-1c02745aae4d?w=600", "Tbilisi, Vake", 40m, "Cooking - Advanced", new Guid("20000000-0000-0000-0000-000000000002") },
                    { new Guid("30000000-0000-0000-0000-000000000007"), 12, new Guid("10000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 21, 9, 0, 0, 0, DateTimeKind.Utc), "Leather wallet workshop: a friendly course for anyone curious about leather crafts. Materials included.", 2, "https://images.unsplash.com/photo-1473188588951-666fce8e7c68?w=600", "Tbilisi, Vake", 35m, "Leather wallet workshop", new Guid("20000000-0000-0000-0000-000000000001") },
                    { new Guid("30000000-0000-0000-0000-000000000008"), 10, new Guid("10000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 25, 9, 0, 0, 0, DateTimeKind.Utc), "Ceramic bowls: a friendly course for anyone curious about ceramic. Materials included.", 2, "https://images.unsplash.com/photo-1565193566173-7a0ee3dbe261?w=600", "Tbilisi, Vake", 30m, "Ceramic bowls", new Guid("20000000-0000-0000-0000-000000000002") },
                    { new Guid("30000000-0000-0000-0000-000000000009"), 25, new Guid("10000000-0000-0000-0000-000000000008"), new DateTime(2026, 11, 1, 9, 0, 0, 0, DateTimeKind.Utc), "Street photography walk: a friendly course for anyone curious about photography. Materials included.", 2, "https://images.unsplash.com/photo-1452587925148-ce544e77e70d?w=600", "Tbilisi, Vake", 15m, "Street photography walk", new Guid("20000000-0000-0000-0000-000000000003") }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "Body", "CreatedAt", "ReadAt", "Title", "UserId" },
                values: new object[] { new Guid("60000000-0000-0000-0000-000000000001"), "Pick your interests to get recommendations.", new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), null, "Welcome to Hobber", new Guid("20000000-0000-0000-0000-000000000004") });

            migrationBuilder.InsertData(
                table: "UserInterests",
                columns: new[] { "CategoryId", "UserId" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000004") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000004") },
                    { new Guid("10000000-0000-0000-0000-000000000004"), new Guid("20000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.InsertData(
                table: "CourseSessions",
                columns: new[] { "Id", "CourseId", "EndsAt", "StartsAt" },
                values: new object[,]
                {
                    { new Guid("40000000-0000-0000-0001-000000000001"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 11, 16, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 16, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0001-000000000002"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 11, 23, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 23, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0001-000000000003"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 11, 30, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 30, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0001-000000000004"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 12, 7, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 7, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0001-000000000005"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 12, 14, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 14, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0001-000000000006"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 12, 21, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 21, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0001-000000000007"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 12, 28, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 28, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0001-000000000008"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2027, 1, 4, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 4, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0001-000000000009"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2027, 1, 11, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 11, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0001-000000000010"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2027, 1, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 18, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0001-000000000011"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2027, 1, 25, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 25, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0001-000000000012"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2027, 2, 1, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 1, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000001"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 11, 23, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 23, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000002"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 11, 30, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 30, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000003"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 12, 7, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 7, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000004"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 12, 14, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 14, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000005"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 12, 21, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 21, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000006"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 12, 28, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 28, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000007"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2027, 1, 4, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 4, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000008"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2027, 1, 11, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 11, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000009"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2027, 1, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 18, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000010"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2027, 1, 25, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 25, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000011"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2027, 2, 1, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 1, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0002-000000000012"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2027, 2, 8, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 8, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000001"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 11, 12, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 12, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000002"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 11, 19, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 19, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000003"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 11, 26, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 26, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000004"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 12, 3, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 3, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000005"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 12, 10, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 10, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000006"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 12, 17, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 17, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000007"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 12, 24, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 24, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000008"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 12, 31, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 31, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000009"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2027, 1, 7, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 7, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000010"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2027, 1, 14, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 14, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000011"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2027, 1, 21, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 21, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0003-000000000012"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2027, 1, 28, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 28, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000001"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 11, 5, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 5, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000002"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 11, 12, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 12, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000003"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 11, 19, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 19, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000004"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 11, 26, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 26, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000005"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 12, 3, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 3, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000006"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 12, 10, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 10, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000007"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 12, 17, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 17, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000008"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 12, 24, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 24, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000009"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 12, 31, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 31, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000010"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2027, 1, 7, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 7, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000011"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2027, 1, 14, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 14, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0004-000000000012"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2027, 1, 21, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 21, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000001"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 11, 4, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 4, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000002"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 11, 11, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 11, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000003"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 11, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 18, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000004"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 11, 25, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 25, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000005"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 12, 2, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 2, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000006"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 12, 9, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 9, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000007"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 12, 16, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 16, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000008"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 12, 23, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 23, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000009"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 12, 30, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 30, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000010"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2027, 1, 6, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 6, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000011"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2027, 1, 13, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 13, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0005-000000000012"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2027, 1, 20, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 20, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000001"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 12, 2, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 2, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000002"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 12, 9, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 9, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000003"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 12, 16, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 16, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000004"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 12, 23, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 23, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000005"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 12, 30, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 30, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000006"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2027, 1, 6, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 6, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000007"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2027, 1, 13, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 13, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000008"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2027, 1, 20, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 20, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000009"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2027, 1, 27, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 27, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000010"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2027, 2, 3, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 3, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000011"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2027, 2, 10, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 10, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0006-000000000012"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2027, 2, 17, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 17, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000001"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 11, 20, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 20, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000002"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 11, 27, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 27, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000003"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 12, 4, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 4, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000004"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 12, 11, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 11, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000005"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 12, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 18, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000006"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 12, 25, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 25, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000007"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2027, 1, 1, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 1, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000008"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2027, 1, 8, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 8, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000009"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2027, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 15, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000010"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2027, 1, 22, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 22, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000011"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2027, 1, 29, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 29, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0007-000000000012"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2027, 2, 5, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 5, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000001"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2026, 11, 27, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 27, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000002"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2026, 12, 4, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 4, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000003"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2026, 12, 11, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 11, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000004"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2026, 12, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 18, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000005"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2026, 12, 25, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 25, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000006"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2027, 1, 1, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 1, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000007"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2027, 1, 8, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 8, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000008"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2027, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 15, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000009"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2027, 1, 22, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 22, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000010"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2027, 1, 29, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 29, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000011"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2027, 2, 5, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 5, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0008-000000000012"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2027, 2, 12, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 12, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000001"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 1, 11, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 11, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000002"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 1, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 18, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000003"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 1, 25, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 25, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000004"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 2, 1, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 1, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000005"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 2, 8, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 8, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000006"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 2, 15, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 15, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000007"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 2, 22, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 22, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000008"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 3, 1, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 3, 1, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000009"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 3, 8, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 3, 8, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000010"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 3, 15, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 3, 15, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000011"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 3, 22, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 3, 22, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("40000000-0000-0000-0009-000000000012"), new Guid("30000000-0000-0000-0000-000000000009"), new DateTime(2027, 3, 29, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 3, 29, 18, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "Id", "CourseId", "CreatedAt", "StudentId" },
                values: new object[,]
                {
                    { new Guid("50000000-0000-0000-0001-000000000001"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000101") },
                    { new Guid("50000000-0000-0000-0001-000000000002"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000102") },
                    { new Guid("50000000-0000-0000-0001-000000000003"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000103") },
                    { new Guid("50000000-0000-0000-0001-000000000004"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000104") },
                    { new Guid("50000000-0000-0000-0001-000000000005"), new Guid("30000000-0000-0000-0000-000000000001"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000105") },
                    { new Guid("50000000-0000-0000-0002-000000000001"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000101") },
                    { new Guid("50000000-0000-0000-0002-000000000002"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000102") },
                    { new Guid("50000000-0000-0000-0002-000000000003"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000103") },
                    { new Guid("50000000-0000-0000-0002-000000000004"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000104") },
                    { new Guid("50000000-0000-0000-0002-000000000005"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000105") },
                    { new Guid("50000000-0000-0000-0002-000000000006"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000106") },
                    { new Guid("50000000-0000-0000-0002-000000000007"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000107") },
                    { new Guid("50000000-0000-0000-0002-000000000008"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000108") },
                    { new Guid("50000000-0000-0000-0002-000000000009"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000109") },
                    { new Guid("50000000-0000-0000-0002-000000000010"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000110") },
                    { new Guid("50000000-0000-0000-0002-000000000011"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000111") },
                    { new Guid("50000000-0000-0000-0002-000000000012"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000112") },
                    { new Guid("50000000-0000-0000-0002-000000000013"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000113") },
                    { new Guid("50000000-0000-0000-0002-000000000014"), new Guid("30000000-0000-0000-0000-000000000002"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000114") },
                    { new Guid("50000000-0000-0000-0003-000000000001"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000101") },
                    { new Guid("50000000-0000-0000-0003-000000000002"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000102") },
                    { new Guid("50000000-0000-0000-0003-000000000003"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000103") },
                    { new Guid("50000000-0000-0000-0003-000000000004"), new Guid("30000000-0000-0000-0000-000000000003"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000104") },
                    { new Guid("50000000-0000-0000-0004-000000000001"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000101") },
                    { new Guid("50000000-0000-0000-0004-000000000002"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000102") },
                    { new Guid("50000000-0000-0000-0004-000000000003"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000103") },
                    { new Guid("50000000-0000-0000-0004-000000000004"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000104") },
                    { new Guid("50000000-0000-0000-0004-000000000005"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000105") },
                    { new Guid("50000000-0000-0000-0004-000000000006"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000106") },
                    { new Guid("50000000-0000-0000-0004-000000000007"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000107") },
                    { new Guid("50000000-0000-0000-0004-000000000008"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000108") },
                    { new Guid("50000000-0000-0000-0004-000000000009"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000109") },
                    { new Guid("50000000-0000-0000-0004-000000000010"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000110") },
                    { new Guid("50000000-0000-0000-0004-000000000011"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000111") },
                    { new Guid("50000000-0000-0000-0004-000000000012"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000112") },
                    { new Guid("50000000-0000-0000-0004-000000000013"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000113") },
                    { new Guid("50000000-0000-0000-0004-000000000014"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000114") },
                    { new Guid("50000000-0000-0000-0004-000000000015"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000115") },
                    { new Guid("50000000-0000-0000-0004-000000000016"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000116") },
                    { new Guid("50000000-0000-0000-0004-000000000017"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000117") },
                    { new Guid("50000000-0000-0000-0004-000000000018"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000118") },
                    { new Guid("50000000-0000-0000-0004-000000000019"), new Guid("30000000-0000-0000-0000-000000000004"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000119") },
                    { new Guid("50000000-0000-0000-0005-000000000001"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000101") },
                    { new Guid("50000000-0000-0000-0005-000000000002"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000102") },
                    { new Guid("50000000-0000-0000-0005-000000000003"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000103") },
                    { new Guid("50000000-0000-0000-0005-000000000004"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000104") },
                    { new Guid("50000000-0000-0000-0005-000000000005"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000105") },
                    { new Guid("50000000-0000-0000-0005-000000000006"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000106") },
                    { new Guid("50000000-0000-0000-0005-000000000007"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000107") },
                    { new Guid("50000000-0000-0000-0005-000000000008"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000108") },
                    { new Guid("50000000-0000-0000-0005-000000000009"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000109") },
                    { new Guid("50000000-0000-0000-0005-000000000010"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000110") },
                    { new Guid("50000000-0000-0000-0005-000000000011"), new Guid("30000000-0000-0000-0000-000000000005"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000111") },
                    { new Guid("50000000-0000-0000-0006-000000000001"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000101") },
                    { new Guid("50000000-0000-0000-0006-000000000002"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000102") },
                    { new Guid("50000000-0000-0000-0006-000000000003"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000103") },
                    { new Guid("50000000-0000-0000-0006-000000000004"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000104") },
                    { new Guid("50000000-0000-0000-0006-000000000005"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000105") },
                    { new Guid("50000000-0000-0000-0006-000000000006"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000106") },
                    { new Guid("50000000-0000-0000-0006-000000000007"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000107") },
                    { new Guid("50000000-0000-0000-0006-000000000008"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000108") },
                    { new Guid("50000000-0000-0000-0006-000000000009"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000109") },
                    { new Guid("50000000-0000-0000-0006-000000000010"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000110") },
                    { new Guid("50000000-0000-0000-0006-000000000011"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000111") },
                    { new Guid("50000000-0000-0000-0006-000000000012"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000112") },
                    { new Guid("50000000-0000-0000-0006-000000000013"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000113") },
                    { new Guid("50000000-0000-0000-0006-000000000014"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000114") },
                    { new Guid("50000000-0000-0000-0006-000000000015"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000115") },
                    { new Guid("50000000-0000-0000-0006-000000000016"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000116") },
                    { new Guid("50000000-0000-0000-0006-000000000017"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000117") },
                    { new Guid("50000000-0000-0000-0006-000000000018"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000118") },
                    { new Guid("50000000-0000-0000-0006-000000000019"), new Guid("30000000-0000-0000-0000-000000000006"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000119") },
                    { new Guid("50000000-0000-0000-0007-000000000001"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000101") },
                    { new Guid("50000000-0000-0000-0007-000000000002"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000102") },
                    { new Guid("50000000-0000-0000-0007-000000000003"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000103") },
                    { new Guid("50000000-0000-0000-0007-000000000004"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000104") },
                    { new Guid("50000000-0000-0000-0007-000000000005"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000105") },
                    { new Guid("50000000-0000-0000-0007-000000000006"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000106") },
                    { new Guid("50000000-0000-0000-0007-000000000007"), new Guid("30000000-0000-0000-0000-000000000007"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000107") },
                    { new Guid("50000000-0000-0000-0008-000000000001"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000101") },
                    { new Guid("50000000-0000-0000-0008-000000000002"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000102") },
                    { new Guid("50000000-0000-0000-0008-000000000003"), new Guid("30000000-0000-0000-0000-000000000008"), new DateTime(2026, 10, 20, 12, 0, 0, 0, DateTimeKind.Utc), new Guid("20000000-0000-0000-0000-000000000103") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000003"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000004"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000005"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000006"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000007"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000008"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000009"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000010"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000011"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000012"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000001"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000002"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000003"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000004"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000005"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000006"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000007"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000008"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000009"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000010"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000011"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000012"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000001"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000002"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000003"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000004"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000005"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000006"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000007"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000008"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000009"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000010"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000011"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000012"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000001"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000002"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000003"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000004"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000005"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000006"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000007"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000008"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000009"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000010"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000011"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000012"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000001"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000002"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000003"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000004"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000005"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000006"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000007"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000008"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000009"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000010"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000011"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000012"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000001"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000002"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000003"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000004"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000005"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000006"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000007"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000008"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000009"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000010"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000011"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000012"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000001"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000002"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000003"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000004"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000005"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000006"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000007"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000008"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000009"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000010"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000011"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000012"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000001"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000002"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000003"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000004"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000005"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000006"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000007"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000008"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000009"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000010"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000011"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000012"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000001"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000002"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000003"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000004"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000005"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000006"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000007"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000008"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000009"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000010"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000011"));

            migrationBuilder.DeleteData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000012"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0001-000000000001"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0001-000000000002"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0001-000000000003"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0001-000000000004"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0001-000000000005"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000001"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000002"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000003"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000004"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000005"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000006"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000007"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000008"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000009"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000010"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000011"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000012"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000013"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0002-000000000014"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0003-000000000001"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0003-000000000002"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0003-000000000003"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0003-000000000004"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000001"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000002"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000003"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000004"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000005"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000006"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000007"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000008"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000009"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000010"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000011"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000012"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000013"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000014"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000015"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000016"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000017"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000018"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0004-000000000019"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0005-000000000001"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0005-000000000002"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0005-000000000003"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0005-000000000004"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0005-000000000005"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0005-000000000006"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0005-000000000007"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0005-000000000008"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0005-000000000009"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0005-000000000010"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0005-000000000011"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000001"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000002"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000003"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000004"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000005"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000006"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000007"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000008"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000009"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000010"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000011"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000012"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000013"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000014"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000015"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000016"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000017"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000018"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0006-000000000019"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0007-000000000001"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0007-000000000002"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0007-000000000003"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0007-000000000004"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0007-000000000005"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0007-000000000006"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0007-000000000007"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0008-000000000001"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0008-000000000002"));

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "Id",
                keyValue: new Guid("50000000-0000-0000-0008-000000000003"));

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: new Guid("60000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumns: new[] { "CategoryId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000001"), new Guid("20000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumns: new[] { "CategoryId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000003"), new Guid("20000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "UserInterests",
                keyColumns: new[] { "CategoryId", "UserId" },
                keyValues: new object[] { new Guid("10000000-0000-0000-0000-000000000004"), new Guid("20000000-0000-0000-0000-000000000004") });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000120"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000101"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000102"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000103"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000104"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000105"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000106"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000107"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000108"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000109"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000110"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000111"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000112"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000113"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000114"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000115"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000116"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000117"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000118"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000119"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("20000000-0000-0000-0000-000000000003"));
        }
    }
}
