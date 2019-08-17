using Microsoft.EntityFrameworkCore.Migrations;

namespace Group1APIProject.Migrations.Data
{
    public partial class Newproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_RecipeFavorites_ResultId",
                table: "RecipeFavorites",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeFavorites_Result_ResultId",
                table: "RecipeFavorites",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "ResultId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeFavorites_Result_ResultId",
                table: "RecipeFavorites");

            migrationBuilder.DropIndex(
                name: "IX_RecipeFavorites_ResultId",
                table: "RecipeFavorites");
        }
    }
}
