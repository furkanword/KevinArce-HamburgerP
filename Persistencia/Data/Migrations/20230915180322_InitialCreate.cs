using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistencia.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.IdCategoria);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chef",
                columns: table => new
                {
                    IdChef = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especialidad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chef", x => x.IdChef);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ingrediente",
                columns: table => new
                {
                    IdIngrediente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreIngrediente = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DescripcionIngrediente = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrecioIngrediente = table.Column<int>(type: "int", nullable: false),
                    StockIngrediente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingrediente", x => x.IdIngrediente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "hamburguesa",
                columns: table => new
                {
                    IdHamburguesa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreHamburguesa = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Categoria_id = table.Column<int>(type: "int", nullable: false),
                    CategoriasId = table.Column<int>(type: "int", nullable: true),
                    PrecioHamburguesa = table.Column<int>(type: "int", nullable: false),
                    Chef_id = table.Column<int>(type: "int", nullable: false),
                    ChefsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hamburguesa", x => x.IdHamburguesa);
                    table.ForeignKey(
                        name: "FK_hamburguesa_categoria_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "categoria",
                        principalColumn: "IdCategoria");
                    table.ForeignKey(
                        name: "FK_hamburguesa_chef_ChefsId",
                        column: x => x.ChefsId,
                        principalTable: "chef",
                        principalColumn: "IdChef");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "hamburguesa_ingrediente",
                columns: table => new
                {
                    Hamburguesa_id = table.Column<int>(type: "int", nullable: false),
                    Ingrediente_Id = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hamburguesa_ingrediente", x => new { x.Hamburguesa_id, x.Ingrediente_Id });
                    table.ForeignKey(
                        name: "FK_hamburguesa_ingrediente_hamburguesa_Hamburguesa_id",
                        column: x => x.Hamburguesa_id,
                        principalTable: "hamburguesa",
                        principalColumn: "IdHamburguesa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hamburguesa_ingrediente_ingrediente_Ingrediente_Id",
                        column: x => x.Ingrediente_Id,
                        principalTable: "ingrediente",
                        principalColumn: "IdIngrediente",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_hamburguesa_CategoriasId",
                table: "hamburguesa",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_hamburguesa_ChefsId",
                table: "hamburguesa",
                column: "ChefsId");

            migrationBuilder.CreateIndex(
                name: "IX_hamburguesa_ingrediente_Ingrediente_Id",
                table: "hamburguesa_ingrediente",
                column: "Ingrediente_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hamburguesa_ingrediente");

            migrationBuilder.DropTable(
                name: "hamburguesa");

            migrationBuilder.DropTable(
                name: "ingrediente");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "chef");
        }
    }
}
