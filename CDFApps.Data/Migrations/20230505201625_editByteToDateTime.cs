using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDFApps.Data.Migrations
{
    /// <inheritdoc />
    public partial class editByteToDateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WarehouseJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalRef = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReceived = table.Column<bool>(type: "bit", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boxes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseJobsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoxReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceivedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boxes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boxes_WarehouseJobs_WarehouseJobsId",
                        column: x => x.WarehouseJobsId,
                        principalTable: "WarehouseJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boxes_WarehouseJobsId",
                table: "Boxes",
                column: "WarehouseJobsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boxes");

            migrationBuilder.DropTable(
                name: "WarehouseJobs");
        }
    }
}
