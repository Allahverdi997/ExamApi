using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Application");

            migrationBuilder.EnsureSchema(
                name: "Exam");

            migrationBuilder.EnsureSchema(
                name: "Auth");

            migrationBuilder.CreateTable(
                name: "Configuration",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JWTKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AzureConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AzureStorageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AzureFileContainer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionNotifications",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                schema: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "char(3)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatorUserId = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatorUserId = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<decimal>(type: "NUMERIC(5,0)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Class = table.Column<decimal>(type: "NUMERIC(2,0)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatorUserId = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatorUserId = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatorUserId = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamResults",
                schema: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "date", nullable: false),
                    ExamValue = table.Column<decimal>(type: "NUMERIC(1,0)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatorUserId = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamResults_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Exam",
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamResults_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Exam",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LessonInfos",
                schema: "Exam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<decimal>(type: "NUMERIC(2,0)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatorUserId = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LessonInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LessonInfos_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalSchema: "Exam",
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LessonInfos_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "Exam",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivs",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatorUserId = table.Column<int>(type: "int", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPrivs_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Auth",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPrivs_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Application",
                table: "Configuration",
                columns: new[] { "Id", "Active", "AzureConnectionString", "AzureFileContainer", "AzureStorageUrl", "JWTKey" },
                values: new object[] { 1, true, "AzureConnectionString", "files", "AzureStorageUrl", "Exam.Api29051997" });

            migrationBuilder.InsertData(
                schema: "Application",
                table: "ExceptionNotifications",
                columns: new[] { "Id", "Active", "Description", "Key" },
                values: new object[,]
                {
                    { 1, true, "İstifadəçi identifikasiyası uğursuz oldu və ya token etibarsızdır.", "AuthorizedException" },
                    { 2, true, "Göndərilən məlumatlarda sintaksis və ya məntiqi xəta var.", "BadRequestException" },
                    { 3, true, "Gözlənilməyən ümumi bir xəta baş verdi.", "GeneralException" },
                    { 4, true, "Modelin validasiyası uğursuz oldu (ModelState invalid).", "ModelStateException" },
                    { 5, true, "İstənilən resurs tapılmadı.", "NotFoundException" },
                    { 6, true, "İstifadəçinin bu əməliyyatı yerinə yetirməyə icazəsi yoxdur.", "PermissionException" },
                    { 7, true, "Server daxilində gözlənilməyən bir xəta baş verdi.", "ServerException" },
                    { 8, true, "Məlumat bazası ilə əlaqə və ya sorğu icrası zamanı xəta baş verdi.", "SqlServerException" }
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Roles",
                columns: new[] { "Id", "Active", "CreateDate", "Description", "LastUpdateDate", "LastUpdatorUserId", "Name" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistemin tam idarəetmə hüququ olan istifadəçi", null, null, "ADMIN" },
                    { 2, true, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Istifadəçi Rolu", null, null, "USER" }
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "Users",
                columns: new[] { "Id", "Active", "CreateDate", "Description", "ExpiredDate", "LastUpdateDate", "LastUpdatorUserId", "Password", "RefreshToken", "RefreshTokenExpiration", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sistem administratoru", new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "17UZgL7MirVuqQ0BOVpDCLm/IAD1C5J9+9r1HsdzVas=", null, null, 1, "admin" },
                    { 2, true, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Istifadəçi", new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "hRfgvPCqzw6pzRryrHzXVeECUaF+AHbvDj6UL7vCfsE=", null, null, 2, "user" }
                });

            migrationBuilder.InsertData(
                schema: "Auth",
                table: "UserPrivs",
                columns: new[] { "Id", "Active", "CreateDate", "ExpiredDate", "LastUpdateDate", "LastUpdatorUserId", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 1 },
                    { 2, true, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_LessonId",
                schema: "Exam",
                table: "ExamResults",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_StudentId",
                schema: "Exam",
                table: "ExamResults",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonInfos_LessonId",
                schema: "Exam",
                table: "LessonInfos",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LessonInfos_TeacherId",
                schema: "Exam",
                table: "LessonInfos",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivs_RoleId",
                schema: "Auth",
                table: "UserPrivs",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivs_UserId",
                schema: "Auth",
                table: "UserPrivs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuration",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "ExamResults",
                schema: "Exam");

            migrationBuilder.DropTable(
                name: "ExceptionNotifications",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "LessonInfos",
                schema: "Exam");

            migrationBuilder.DropTable(
                name: "UserPrivs",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "Exam");

            migrationBuilder.DropTable(
                name: "Lessons",
                schema: "Exam");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "Exam");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Auth");
        }
    }
}
