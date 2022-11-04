using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aggregation.Migrations.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AggregateData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ObjectNumber = table.Column<int>(type: "int", nullable: true),
                    PPlus = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    PLTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PMinus = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AggregateData", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AggregateData");
        }
    }
}
