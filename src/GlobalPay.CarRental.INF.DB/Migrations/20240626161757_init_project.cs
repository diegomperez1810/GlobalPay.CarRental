using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlobalPay.CarRental.INF.DB.Migrations
{
    /// <inheritdoc />
    public partial class init_project : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Rental");

            migrationBuilder.CreateTable(
                name: "Car",
                schema: "Rental",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Mark = table.Column<string>(type: "varchar(100)", nullable: false),
                    Model = table.Column<string>(type: "varchar(100)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "varchar(100)", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fee",
                schema: "Rental",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeeSurchargeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BasePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CarType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraDaySurcharge = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fee_Fee_FeeSurchargeId",
                        column: x => x.FeeSurchargeId,
                        principalSchema: "Rental",
                        principalTable: "Fee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarHire",
                schema: "Rental",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentalDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ScheduledReturnDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Surcharge = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarHire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarHire_Car_CarId",
                        column: x => x.CarId,
                        principalSchema: "Rental",
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarHire_Fee_FeeId",
                        column: x => x.FeeId,
                        principalSchema: "Rental",
                        principalTable: "Fee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                schema: "Rental",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RateRatio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Period_Fee_FeeId",
                        column: x => x.FeeId,
                        principalSchema: "Rental",
                        principalTable: "Fee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarHire_CarId",
                schema: "Rental",
                table: "CarHire",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarHire_FeeId",
                schema: "Rental",
                table: "CarHire",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fee_FeeSurchargeId",
                schema: "Rental",
                table: "Fee",
                column: "FeeSurchargeId");

            migrationBuilder.CreateIndex(
                name: "IX_Period_FeeId",
                schema: "Rental",
                table: "Period",
                column: "FeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarHire",
                schema: "Rental");

            migrationBuilder.DropTable(
                name: "Period",
                schema: "Rental");

            migrationBuilder.DropTable(
                name: "Car",
                schema: "Rental");

            migrationBuilder.DropTable(
                name: "Fee",
                schema: "Rental");
        }
    }
}
