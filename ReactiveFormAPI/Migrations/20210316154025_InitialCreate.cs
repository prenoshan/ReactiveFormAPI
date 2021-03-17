using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Diagnostics;
using System.IO;

namespace ReactiveFormAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            var insertSproc = Environment.CurrentDirectory + @"\scripts\sp_insertUserDetails.sql";

            Debug.WriteLine(insertSproc);

            migrationBuilder.Sql(File.ReadAllText(insertSproc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
