﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CDFApps.Data.Migrations
{
    /// <inheritdoc />
    public partial class Scan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsScanned",
                table: "Boxes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsScanned",
                table: "Boxes");
        }
    }
}
