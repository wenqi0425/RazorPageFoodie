using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPageFoodie.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipeItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
