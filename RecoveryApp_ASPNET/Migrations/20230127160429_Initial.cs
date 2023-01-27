using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RecoveryAppASPNET.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseRecovery",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Stage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CoverageValue = table.Column<double>(type: "float", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChargeBack = table.Column<bool>(type: "bit", nullable: true),
                    ChargeBackDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InitialTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SinistroType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoStatus = table.Column<bool>(type: "bit", nullable: true),
                    Franchise = table.Column<double>(type: "float", nullable: true),
                    FranchiseRate = table.Column<double>(type: "float", nullable: true),
                    DiscountValue = table.Column<double>(type: "float", nullable: true),
                    Payment = table.Column<bool>(type: "bit", nullable: true),
                    RepairValue = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseRecovery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bondsmans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bondsmans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bondsmans_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecidivistCustomer = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BondsmanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plans_Bondsmans_BondsmanId",
                        column: x => x.BondsmanId,
                        principalTable: "Bondsmans",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Plans_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanCases",
                columns: table => new
                {
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CaseRecoveryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanCases", x => new { x.PlanId, x.CaseId });
                    table.ForeignKey(
                        name: "FK_PlanCases_CaseRecovery_CaseRecoveryId",
                        column: x => x.CaseRecoveryId,
                        principalTable: "CaseRecovery",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanCases_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Complement", "Country", "State", "Street", "ZipCode" },
                values: new object[] { new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), "Berilo", "", "Brasil", "MG", "Rua das Flores", "35485-300" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Cpf", "Gender", "LastName", "Name", "Phone" },
                values: new object[] { new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"), new Guid("90d10994-3bdd-4ca2-a178-6a35fd653c59"), "14512-45", 0, "Wilson", "Paulo", "18 54754-46456" });

            migrationBuilder.InsertData(
                table: "Plans",
                columns: new[] { "Id", "BondsmanId", "Code", "CreateAt", "CustomerId", "FinalDate", "IsActive", "RecidivistCustomer", "Value" },
                values: new object[] { new Guid("f7e82895-0783-470a-a0d6-48b0f2be68b6"), null, "XJ420", new DateTime(2023, 1, 27, 13, 4, 29, 35, DateTimeKind.Local).AddTicks(4499), new Guid("98474b8e-d713-401e-8aee-acb7353f97bb"), null, true, false, 2000.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Bondsmans_AddressId",
                table: "Bondsmans",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanCases_CaseRecoveryId",
                table: "PlanCases",
                column: "CaseRecoveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_BondsmanId",
                table: "Plans",
                column: "BondsmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_CustomerId",
                table: "Plans",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanCases");

            migrationBuilder.DropTable(
                name: "CaseRecovery");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Bondsmans");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
