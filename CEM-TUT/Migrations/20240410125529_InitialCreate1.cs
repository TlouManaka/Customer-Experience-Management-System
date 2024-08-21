using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CEM_TUT.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceProviderproviderId",
                table: "services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "servicesProviders",
                columns: table => new
                {
                    providerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    providerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicesProviders", x => x.providerId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_services_ServiceProviderproviderId",
                table: "services",
                column: "ServiceProviderproviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_services_servicesProviders_ServiceProviderproviderId",
                table: "services",
                column: "ServiceProviderproviderId",
                principalTable: "servicesProviders",
                principalColumn: "providerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_services_servicesProviders_ServiceProviderproviderId",
                table: "services");

            migrationBuilder.DropTable(
                name: "servicesProviders");

            migrationBuilder.DropIndex(
                name: "IX_services_ServiceProviderproviderId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "ServiceProviderproviderId",
                table: "services");
        }
    }
}
