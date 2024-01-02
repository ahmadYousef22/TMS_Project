using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingManagment.Repository.Migrations
{
    public partial class all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.CreateTable(
                name: "LookupCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(type: "int", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LookupCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lookup_LookupCategory_LookupCategoryId",
                        column: x => x.LookupCategoryId,
                        principalTable: "LookupCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Security",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Security",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Security",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TraineeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalPresentationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EvaluationScore = table.Column<double>(type: "float", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingResultId = table.Column<int>(type: "int", nullable: true),
                    TrainingTopicId = table.Column<int>(type: "int", nullable: true),
                    TrainingTypeId = table.Column<int>(type: "int", nullable: true),
                    TrainingStatusId = table.Column<int>(type: "int", nullable: true),
                    TrainerNameId = table.Column<int>(type: "int", nullable: true),
                    LookupYearId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Session_Lookup_LookupYearId",
                        column: x => x.LookupYearId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Session_Lookup_TrainerNameId",
                        column: x => x.TrainerNameId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Session_Lookup_TrainingResultId",
                        column: x => x.TrainingResultId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Session_Lookup_TrainingStatusId",
                        column: x => x.TrainingStatusId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Session_Lookup_TrainingTopicId",
                        column: x => x.TrainingTopicId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Session_Lookup_TrainingTypeId",
                        column: x => x.TrainingTypeId,
                        principalTable: "Lookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LookupCategory",
                columns: new[] { "CategoryId", "Code", "CreatedBy", "CreatedOn", "Description", "IsActive", "IsDeleted", "ModifyBy", "ModifyOn", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 100, 1, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(6942), "Training Type That TPS Provided", true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "نوع التدريب", "Training Type" },
                    { 200, 2, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(8585), "Training Topics That TPS Provided", true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "موضوعات التدريب", "Training Topics" },
                    { 300, 3, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(8591), "Training Status", true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "حالة التدريب", "Training Status" },
                    { 400, 4, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(8596), "Training Result", true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "نتيجة التدريب", "Training Result" },
                    { 500, 5, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(8601), "Trainer Name", true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "أسم المدرب", "Trainer Name" },
                    { 600, 6, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 143, DateTimeKind.Local).AddTicks(8607), "Training Year That TPS Provided", true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "السنة", "Year" }
                });

            migrationBuilder.InsertData(
                table: "Lookup",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "Description", "IsActive", "IsDeleted", "LookupCategoryId", "ModifyBy", "ModifyOn", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 1, 1, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9062), "", true, false, 100, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "عمل", "Work" },
                    { 32, 2029, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9910), "", true, false, 600, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2029", "2029" },
                    { 31, 2028, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9903), "", true, false, 600, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2028", "2028" },
                    { 30, 2027, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9896), "", true, false, 600, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2027", "2027" },
                    { 29, 2026, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9889), "", true, false, 600, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2026", "2026" },
                    { 28, 2025, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9882), "", true, false, 600, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2025", "2025" },
                    { 27, 2024, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9875), "", true, false, 600, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2024", "2024" },
                    { 26, 2023, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9869), "", true, false, 600, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2023", "2023" },
                    { 25, 8, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9862), "", true, false, 500, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "أحمد سويلم", "Ahmed Sweilem" },
                    { 24, 7, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9855), "", true, false, 500, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "زكريا لافي", "Zakaria Lafi" },
                    { 23, 6, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9848), "", true, false, 500, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "صفاء", "Safaa" },
                    { 22, 5, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9842), "", true, false, 500, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "محمد عبده", "Mohammad Ibdah" },
                    { 21, 4, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9835), "", true, false, 500, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "محمد حماد", "Mohammad Hamad" },
                    { 20, 3, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9828), "", true, false, 500, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مريم السعداوي", "Mariam AlSadawi" },
                    { 19, 2, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9821), "", true, false, 500, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "لميس حوراني", "Lamees Hourani" },
                    { 18, 1, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9815), "", true, false, 500, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "خالد سلامة", "Khalid Salameh" },
                    { 17, 4, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9808), "", true, false, 400, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "استقال", "Quit" },
                    { 16, 3, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9800), "", true, false, 400, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مرفوض", "Rejected" },
                    { 2, 2, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9701), "", true, false, 100, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "جامعة", "University" },
                    { 3, 1, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9709), "", true, false, 200, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), ".Net", "Dot Net" },
                    { 4, 2, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9716), "", true, false, 200, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "محلل أعمال", "Business Analyst" },
                    { 5, 3, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9724), "", true, false, 200, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مراقبة الجودة", "Quality Control" },
                    { 6, 4, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9731), "", true, false, 200, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "بنية الأنظمة", "Infrastructure" },
                    { 7, 5, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9738), "", true, false, 200, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "واجهة المستخدم وتجربة المستخدم", "UI UX" },
                    { 33, 2030, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9916), "", true, false, 600, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2030", "2030" },
                    { 8, 6, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9745), "", true, false, 200, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الموارد البشرية", "Human Resources" },
                    { 10, 8, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9759), "", true, false, 200, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الذكاء الاصطناعي", "AI" },
                    { 11, 1, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9766), "", true, false, 300, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "نشط", "Active" },
                    { 12, 2, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9773), "", true, false, 300, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "قيد الانتظار", "Pending" },
                    { 13, 3, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9779), "", true, false, 300, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "مكتمل", "Finished" },
                    { 14, 1, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9786), "", true, false, 400, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "الانضمام إلى فريق TPS", "Joining TPS Team" },
                    { 15, 2, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9793), "", true, false, 400, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "معلق", "On Hold" },
                    { 9, 7, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9752), "", true, false, 200, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "المالية", "Finance" },
                    { 34, 2031, "Malek Hamdan", new DateTime(2023, 9, 24, 12, 9, 40, 145, DateTimeKind.Local).AddTicks(9923), "", true, false, 600, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2031", "2031" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lookup_LookupCategoryId",
                table: "Lookup",
                column: "LookupCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Security",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Security",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Session_LookupYearId",
                table: "Session",
                column: "LookupYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_TrainerNameId",
                table: "Session",
                column: "TrainerNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_TrainingResultId",
                table: "Session",
                column: "TrainingResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_TrainingStatusId",
                table: "Session",
                column: "TrainingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_TrainingTopicId",
                table: "Session",
                column: "TrainingTopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Session_TrainingTypeId",
                table: "Session",
                column: "TrainingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Security",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Security",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Security",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Security",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Security",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Lookup");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "LookupCategory");
        }
    }
}
