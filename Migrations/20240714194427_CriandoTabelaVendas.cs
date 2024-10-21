using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PimWeb.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaVendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataVe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DataEn = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    QuantidadeItens = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Vendedor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendas");
        }
    }
}
