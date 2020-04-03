using Microsoft.EntityFrameworkCore.Migrations;

namespace TripAdvisorForEducation.Data.Migrations
{
    public partial class ChangedApplicationUserToCompanyUserInProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_AspNetUsers_CompanyUserId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CompanyUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CompanyUserId",
                table: "Product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyUserId",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CompanyUserId",
                table: "Product",
                column: "CompanyUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_AspNetUsers_CompanyUserId",
                table: "Product",
                column: "CompanyUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
