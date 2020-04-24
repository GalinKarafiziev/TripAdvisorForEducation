using Microsoft.EntityFrameworkCore.Migrations;

namespace TripAdvisorForEducation.Data.Migrations
{
    public partial class AddedPendingCompanyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PendingCompanies",
                columns: table => new
                {
                    PendingCompanyId = table.Column<string>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 60, nullable: true),
                    Website = table.Column<string>(maxLength: 60, nullable: true),
                    Email = table.Column<string>(maxLength: 60, nullable: true),
                    FirstName = table.Column<string>(maxLength: 60, nullable: true),
                    LastName = table.Column<string>(maxLength: 60, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 60, nullable: true),
                    Country = table.Column<string>(maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendingCompanies", x => x.PendingCompanyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PendingCompanies");
        }
    }
}
