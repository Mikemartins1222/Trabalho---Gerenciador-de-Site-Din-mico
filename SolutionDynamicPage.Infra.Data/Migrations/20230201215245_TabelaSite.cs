using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolutionDynamicPage.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TabelaSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CellPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageBanner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                  
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Address", "BusinessName", "CellPhone", "Description", "Email", "FacebookAdress", "FooterDescription", "ImageBanner", "ImageDescription", "ImageLogo", "InstagramAdress", "Phone", "ProfileName", "Title" },
                values: new object[] { 1, "1600 Amphitheatre Parkway, Mountain View", "Sua Marca", "47933224455", "Descrição do Negócio", "empresa@empresa.com", "@empresa", "Transforme as pessoas que encontram você, novos clientes com um Perfil da Empresa gratuito para seu estabelecimento físico ou sua área de cobertura.", "~/img/banner.jpg", "~/img/banner.jpg", "~/img/banner.jpg", null, "4733223322", "Main Profile", "Bom te ver por aqui!" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password" },
                values: new object[] { 1, "mike", "root" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
