﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SilverFrame.Model.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PicturePath = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    include = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
