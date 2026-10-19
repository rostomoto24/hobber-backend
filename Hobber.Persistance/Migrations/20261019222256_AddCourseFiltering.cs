using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hobber.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseFiltering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "CourseSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StartMinutes",
                table: "CourseSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                columns: new[] { "DisplayOrder", "ParentId" },
                values: new object[] { 11, new Guid("10000000-0000-0000-0000-000000000101") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"),
                columns: new[] { "DisplayOrder", "ParentId" },
                values: new object[] { 12, new Guid("10000000-0000-0000-0000-000000000102") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"),
                columns: new[] { "DisplayOrder", "ParentId" },
                values: new object[] { 13, new Guid("10000000-0000-0000-0000-000000000102") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"),
                columns: new[] { "DisplayOrder", "ParentId" },
                values: new object[] { 14, new Guid("10000000-0000-0000-0000-000000000102") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"),
                columns: new[] { "DisplayOrder", "ParentId" },
                values: new object[] { 15, new Guid("10000000-0000-0000-0000-000000000102") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000006"),
                columns: new[] { "DisplayOrder", "ParentId" },
                values: new object[] { 16, new Guid("10000000-0000-0000-0000-000000000103") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000007"),
                columns: new[] { "DisplayOrder", "ParentId" },
                values: new object[] { 17, new Guid("10000000-0000-0000-0000-000000000101") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000008"),
                columns: new[] { "DisplayOrder", "ParentId" },
                values: new object[] { 18, new Guid("10000000-0000-0000-0000-000000000104") });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Accent", "DisplayOrder", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000101"), 1, 1, "Sport", null },
                    { new Guid("10000000-0000-0000-0000-000000000102"), 3, 2, "Arts & crafts", null },
                    { new Guid("10000000-0000-0000-0000-000000000103"), 2, 3, "Food & drink", null },
                    { new Guid("10000000-0000-0000-0000-000000000104"), 4, 4, "Media", null }
                });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000001"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000002"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000003"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000004"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000005"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000006"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000007"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000008"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000009"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000010"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000011"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0001-000000000012"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 1, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000001"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2026, 11, 24, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2026, 11, 24, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000002"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2026, 12, 1, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2026, 12, 1, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000003"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2026, 12, 8, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2026, 12, 8, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000004"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2026, 12, 15, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2026, 12, 15, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000005"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2026, 12, 22, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2026, 12, 22, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000006"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2026, 12, 29, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2026, 12, 29, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000007"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2027, 1, 5, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2027, 1, 5, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000008"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2027, 1, 12, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2027, 1, 12, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000009"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2027, 1, 19, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2027, 1, 19, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000010"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2027, 1, 26, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2027, 1, 26, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000011"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2027, 2, 2, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2027, 2, 2, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000012"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 2, new DateTime(2027, 2, 9, 9, 0, 0, 0, DateTimeKind.Utc), 450, new DateTime(2027, 2, 9, 7, 30, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000001"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000002"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000003"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000004"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000005"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000006"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000007"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000008"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000009"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000010"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000011"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0003-000000000012"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 4, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000001"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2026, 11, 5, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2026, 11, 5, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000002"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2026, 11, 12, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2026, 11, 12, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000003"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2026, 11, 19, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2026, 11, 19, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000004"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2026, 11, 26, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2026, 11, 26, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000005"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2026, 12, 3, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2026, 12, 3, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000006"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2026, 12, 10, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2026, 12, 10, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000007"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2026, 12, 17, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2026, 12, 17, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000008"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2026, 12, 24, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2026, 12, 24, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000009"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2026, 12, 31, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2026, 12, 31, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000010"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2027, 1, 7, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2027, 1, 7, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000011"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2027, 1, 14, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2027, 1, 14, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000012"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 4, new DateTime(2027, 1, 21, 20, 30, 0, 0, DateTimeKind.Utc), 1140, new DateTime(2027, 1, 21, 19, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000001"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2026, 11, 4, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2026, 11, 4, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000002"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2026, 11, 11, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2026, 11, 11, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000003"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2026, 11, 18, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2026, 11, 18, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000004"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2026, 11, 25, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2026, 11, 25, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000005"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2026, 12, 2, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2026, 12, 2, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000006"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2026, 12, 9, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2026, 12, 9, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000007"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2026, 12, 16, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2026, 12, 16, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000008"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2026, 12, 23, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2026, 12, 23, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000009"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2026, 12, 30, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2026, 12, 30, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000010"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2027, 1, 6, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2027, 1, 6, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000011"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2027, 1, 13, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2027, 1, 13, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000012"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 3, new DateTime(2027, 1, 20, 21, 30, 0, 0, DateTimeKind.Utc), 1200, new DateTime(2027, 1, 20, 20, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000001"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000002"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000003"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000004"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000005"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000006"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000007"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000008"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000009"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000010"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000011"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0006-000000000012"),
                columns: new[] { "DayOfWeek", "StartMinutes" },
                values: new object[] { 3, 1080 });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000001"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2026, 11, 20, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2026, 11, 20, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000002"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2026, 11, 27, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2026, 11, 27, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000003"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2026, 12, 4, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2026, 12, 4, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000004"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2026, 12, 11, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2026, 12, 11, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000005"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2026, 12, 18, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2026, 12, 18, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000006"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2026, 12, 25, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2026, 12, 25, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000007"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 1, 1, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2027, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000008"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 1, 8, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2027, 1, 8, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000009"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 1, 15, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2027, 1, 15, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000010"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 1, 22, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2027, 1, 22, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000011"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 1, 29, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2027, 1, 29, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000012"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 2, 5, 18, 30, 0, 0, DateTimeKind.Utc), 1020, new DateTime(2027, 2, 5, 17, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000001"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2026, 11, 27, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2026, 11, 27, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000002"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2026, 12, 4, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2026, 12, 4, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000003"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2026, 12, 11, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2026, 12, 11, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000004"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2026, 12, 18, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2026, 12, 18, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000005"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2026, 12, 25, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2026, 12, 25, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000006"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 1, 1, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2027, 1, 1, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000007"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 1, 8, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2027, 1, 8, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000008"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 1, 15, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2027, 1, 15, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000009"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 1, 22, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2027, 1, 22, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000010"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 1, 29, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2027, 1, 29, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000011"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 2, 5, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2027, 2, 5, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000012"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 5, new DateTime(2027, 2, 12, 12, 30, 0, 0, DateTimeKind.Utc), 660, new DateTime(2027, 2, 12, 11, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000001"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 1, 11, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 1, 11, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000002"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 1, 18, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 1, 18, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000003"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 1, 25, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 1, 25, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000004"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 2, 1, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 2, 1, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000005"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 2, 8, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 2, 8, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000006"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 2, 15, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 2, 15, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000007"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 2, 22, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 2, 22, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000008"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 3, 1, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 3, 1, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000009"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 3, 8, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 3, 8, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000010"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 3, 15, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 3, 15, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000011"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 3, 22, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 3, 22, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000012"),
                columns: new[] { "DayOfWeek", "EndsAt", "StartMinutes", "StartsAt" },
                values: new object[] { 1, new DateTime(2027, 3, 29, 11, 30, 0, 0, DateTimeKind.Utc), 600, new DateTime(2027, 3, 29, 10, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"),
                column: "Level",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"),
                column: "Level",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"),
                column: "Level",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"),
                column: "Level",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"),
                column: "Level",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"),
                column: "Level",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"),
                column: "Level",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000008"),
                column: "Level",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000009"),
                column: "Level",
                value: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseSessions_DayOfWeek_StartMinutes",
                table: "CourseSessions",
                columns: new[] { "DayOfWeek", "StartMinutes" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories",
                column: "ParentId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_CourseSessions_DayOfWeek_StartMinutes",
                table: "CourseSessions");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentId",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000101"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000102"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000103"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000104"));

            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "CourseSessions");

            migrationBuilder.DropColumn(
                name: "StartMinutes",
                table: "CourseSessions");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                column: "DisplayOrder",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"),
                column: "DisplayOrder",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"),
                column: "DisplayOrder",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"),
                column: "DisplayOrder",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"),
                column: "DisplayOrder",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000006"),
                column: "DisplayOrder",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000007"),
                column: "DisplayOrder",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000008"),
                column: "DisplayOrder",
                value: 8);

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000001"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 23, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 23, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000002"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 30, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 30, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000003"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 7, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 7, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000004"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 14, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 14, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000005"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 21, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 21, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000006"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 28, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 28, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000007"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 4, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 4, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000008"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 11, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 11, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000009"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 18, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000010"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 25, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 25, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000011"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 2, 1, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 1, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0002-000000000012"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 2, 8, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 8, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000001"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 5, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 5, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000002"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 12, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 12, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000003"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 19, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 19, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000004"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 26, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 26, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000005"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 3, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 3, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000006"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 10, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 10, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000007"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 17, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 17, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000008"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 24, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 24, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000009"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 31, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 31, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000010"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 7, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 7, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000011"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 14, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 14, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0004-000000000012"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 21, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 21, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000001"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 4, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 4, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000002"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 11, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 11, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000003"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 18, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000004"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 25, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 25, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000005"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 2, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 2, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000006"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 9, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 9, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000007"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 16, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 16, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000008"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 23, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 23, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000009"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 30, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 30, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000010"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 6, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 6, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000011"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 13, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 13, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0005-000000000012"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 20, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 20, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000001"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 20, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 20, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000002"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 27, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 27, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000003"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 4, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 4, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000004"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 11, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 11, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000005"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 18, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000006"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 25, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 25, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000007"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 1, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 1, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000008"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 8, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 8, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000009"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 15, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000010"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 22, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 22, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000011"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 29, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 29, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0007-000000000012"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 2, 5, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 5, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000001"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 11, 27, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 11, 27, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000002"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 4, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 4, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000003"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 11, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 11, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000004"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 18, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000005"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2026, 12, 25, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2026, 12, 25, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000006"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 1, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 1, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000007"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 8, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 8, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000008"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 15, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 15, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000009"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 22, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 22, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000010"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 29, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 29, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000011"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 2, 5, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 5, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0008-000000000012"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 2, 12, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 12, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000001"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 11, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 11, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000002"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 18, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 18, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000003"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 1, 25, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 1, 25, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000004"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 2, 1, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 1, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000005"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 2, 8, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 8, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000006"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 2, 15, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 15, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000007"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 2, 22, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 2, 22, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000008"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 3, 1, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 3, 1, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000009"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 3, 8, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 3, 8, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000010"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 3, 15, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 3, 15, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000011"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 3, 22, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 3, 22, 18, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "CourseSessions",
                keyColumn: "Id",
                keyValue: new Guid("40000000-0000-0000-0009-000000000012"),
                columns: new[] { "EndsAt", "StartsAt" },
                values: new object[] { new DateTime(2027, 3, 29, 19, 30, 0, 0, DateTimeKind.Utc), new DateTime(2027, 3, 29, 18, 0, 0, 0, DateTimeKind.Utc) });
        }
    }
}
