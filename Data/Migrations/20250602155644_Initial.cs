using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartBit.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseTypes",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseTypes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
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
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
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
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonetaryFund",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonetaryFund", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonetaryFund_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    MonetaryFundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposit_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Deposit_MonetaryFund_MonetaryFundId",
                        column: x => x.MonetaryFundId,
                        principalTable: "MonetaryFund",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    Observations = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MonetaryFundId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_MonetaryFund_MonetaryFundId",
                        column: x => x.MonetaryFundId,
                        principalTable: "MonetaryFund",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    ExpenseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpenseTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseDetails_ExpenseTypes_ExpenseTypeId",
                        column: x => x.ExpenseTypeId,
                        principalTable: "ExpenseTypes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseDetails_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "08c77f09-af58-4fc7-87d6-d2648c7187cc", 0, "12345678-90ab-cdef-1234-567890abcdef", "admin", true, false, null, "ADMIN", "ADMIN", "AQAAAAIAAYagAAAAEKv6cFHooCRU1s7UzzxW0bkACKmQAyJ3A25yILKJkY4rv2hpyiO+uSfx+p4ZMjkW4A==", null, false, "a1b2c3d4-e5f6-7890-abcd-ef1234567890", false, "admin" });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "Code", "Active", "Description", "Name" },
                values: new object[,]
                {
                    { "0001", true, "Expenses related to the administration and management of the company", "Administrative Expenses" },
                    { "0002", true, "Expenses directly related to the business operations", "Operational Expenses" },
                    { "0003", true, "Expenses related to advertising, promotion, and marketing", "Marketing Expenses" }
                });

            migrationBuilder.InsertData(
                table: "MonetaryFund",
                columns: new[] { "Id", "Active", "ApplicationUserId", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("0e09e00a-ca41-4d01-89ba-f084231c2fe7"), true, "08c77f09-af58-4fc7-87d6-d2648c7187cc", "Cash", 0 },
                    { new Guid("6ca2098b-1126-4515-8ca2-fb503321620d"), true, "08c77f09-af58-4fc7-87d6-d2648c7187cc", "Western Union", 1 },
                    { new Guid("bd6e1302-4fa1-41ea-a91c-260ea6c2278d"), true, "08c77f09-af58-4fc7-87d6-d2648c7187cc", "Bank of Ameryca", 2 }
                });

            migrationBuilder.InsertData(
                table: "Deposit",
                columns: new[] { "Id", "Amount", "ApplicationUserId", "Date", "MonetaryFundId" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), 1500.5, "08c77f09-af58-4fc7-87d6-d2648c7187cc", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0e09e00a-ca41-4d01-89ba-f084231c2fe7") },
                    { new Guid("a2222222-2222-2222-2222-222222222222"), 750.25, "08c77f09-af58-4fc7-87d6-d2648c7187cc", new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("0e09e00a-ca41-4d01-89ba-f084231c2fe7") },
                    { new Guid("b3333333-3333-3333-3333-333333333333"), 2000.0, "08c77f09-af58-4fc7-87d6-d2648c7187cc", new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd6e1302-4fa1-41ea-a91c-260ea6c2278d") },
                    { new Guid("b4444444-4444-4444-4444-444444444444"), 1200.75, "08c77f09-af58-4fc7-87d6-d2648c7187cc", new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bd6e1302-4fa1-41ea-a91c-260ea6c2278d") },
                    { new Guid("c5555555-5555-5555-5555-555555555555"), 500.0, "08c77f09-af58-4fc7-87d6-d2648c7187cc", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ca2098b-1126-4515-8ca2-fb503321620d") },
                    { new Guid("c6666666-6666-6666-6666-666666666666"), 850.29999999999995, "08c77f09-af58-4fc7-87d6-d2648c7187cc", new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ca2098b-1126-4515-8ca2-fb503321620d") }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "ApplicationUserId", "BusinessName", "Date", "DocumentType", "MonetaryFundId", "Observations" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "08c77f09-af58-4fc7-87d6-d2648c7187cc", "Papelería San José", new DateTime(2025, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new Guid("bd6e1302-4fa1-41ea-a91c-260ea6c2278d"), "Office supplies and stationery" },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "08c77f09-af58-4fc7-87d6-d2648c7187cc", "Restaurante El Buen Sabor", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new Guid("6ca2098b-1126-4515-8ca2-fb503321620d"), "Business lunch with client" }
                });

            migrationBuilder.InsertData(
                table: "ExpenseDetails",
                columns: new[] { "Id", "Amount", "ExpenseId", "ExpenseTypeId" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), 75.0, new Guid("11111111-1111-1111-1111-111111111111"), "0001" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), 125.5, new Guid("11111111-1111-1111-1111-111111111111"), "0002" },
                    { new Guid("88888888-8888-8888-8888-888888888888"), 85.75, new Guid("77777777-7777-7777-7777-777777777777"), "0002" },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), 15.25, new Guid("77777777-7777-7777-7777-777777777777"), "0003" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_ApplicationUserId",
                table: "Deposit",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposit_MonetaryFundId",
                table: "Deposit",
                column: "MonetaryFundId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetails_ExpenseId",
                table: "ExpenseDetails",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetails_ExpenseTypeId",
                table: "ExpenseDetails",
                column: "ExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ApplicationUserId",
                table: "Expenses",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_MonetaryFundId",
                table: "Expenses",
                column: "MonetaryFundId");

            migrationBuilder.CreateIndex(
                name: "IX_MonetaryFund_ApplicationUserId",
                table: "MonetaryFund",
                column: "ApplicationUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "ExpenseDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ExpenseTypes");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "MonetaryFund");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
