using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPageFoodie.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    CookingSteps = table.Column<string>(nullable: false),
                    Introduction = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Amount = table.Column<string>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeItems_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CookingSteps", "ImageData", "Introduction", "Name" },
                values: new object[] { 1, @"1) Wash Shiitake and Pak Choi.
2) Fry Shiitake with Østerssauce.
3) Fry Pak Choi together.
Done!", null, "It is a deliouse dish and easily to make.", "Shiitake and Pak Choi with Østerssauce" });

            migrationBuilder.InsertData(
                table: "RecipeItems",
                columns: new[] { "Id", "Amount", "Name", "RecipeId" },
                values: new object[] { 1, "50g", "Shiitake", 1 });

            migrationBuilder.InsertData(
                table: "RecipeItems",
                columns: new[] { "Id", "Amount", "Name", "RecipeId" },
                values: new object[] { 2, "200g", "Pak Choi", 1 });

            migrationBuilder.InsertData(
                table: "RecipeItems",
                columns: new[] { "Id", "Amount", "Name", "RecipeId" },
                values: new object[] { 3, "20g", "Østerssauce", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeItems_RecipeId",
                table: "RecipeItems",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeItems");

            migrationBuilder.DropTable(
                name: "Recipes");
        }
    }
}
