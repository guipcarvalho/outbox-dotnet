using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Migrations
{
    /// <inheritdoc />
    public partial class AddSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "Description", "DateAdded", "DateUpdated" },
                values: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000001"), "GraphQL", "GraphQL is a query language for APIs and a runtime for executing those queries by using a type system you define for your data.", "2024-06-30 23:04:53", "2024-06-30 23:04:53" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "Description", "DateAdded", "DateUpdated" },
                values: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000002"), "Entity Framework Core", "Entity Framework Core is a modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations.", "2024-06-30 23:04:53", "2024-06-30 23:04:53" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name", "Description", "DateAdded", "DateUpdated" },
                values: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000003"), "ASP.NET Core", "ASP.NET Core is a cross-platform, high-performance, open-source framework for building modern, cloud-based, Internet-connected applications.", "2024-06-30 23:04:53", "2024-06-30 23:04:53" });
            
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Rating", "Comment", "CourseId" },
                values: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000001"), 5, "Great course!", Guid.Parse("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Rating", "Comment", "CourseId" },
                values: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000002"), 4, "Good course!", Guid.Parse("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Rating", "Comment", "CourseId" },
                values: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000003"), 3, "Average course!", Guid.Parse("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Rating", "Comment", "CourseId" },
                values: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000004"), 2, "Bad course!", Guid.Parse("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Rating", "Comment", "CourseId" },
                values: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000005"), 1, "Terrible course!", Guid.Parse("00000000-0000-0000-0000-000000000001") });
            
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Rating", "Comment", "CourseId" },
                values: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000006"), 5, "Great course!", Guid.Parse("00000000-0000-0000-0000-000000000002") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValues: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000001") });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValues: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000002") });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValues: new object[] { Guid.Parse("00000000-0000-0000-0000-000000000003") });
            
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: Guid.Parse("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: Guid.Parse("00000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: Guid.Parse("00000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: Guid.Parse("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: Guid.Parse("00000000-0000-0000-0000-000000000005"));
            
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: Guid.Parse("00000000-0000-0000-0000-000000000006"));
        }
    }
}
