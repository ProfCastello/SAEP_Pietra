using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueEquipEletro.Data.Migrations
{
    /// <inheritdoc />
    public partial class Usuarios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Código = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observação = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstoqueAtual = table.Column<int>(type: "int", nullable: false),
                    EstoqueMinimo = table.Column<int>(type: "int", nullable: false),
                    PrecoCusto = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacao_1",
                columns: table => new
                {
                    MovimentacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    DateMovimentação = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao_1", x => x.MovimentacaoId);
                    table.ForeignKey(
                        name: "FK_Movimentacao_1_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movimentacao_1_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_1_ProdutoId",
                table: "Movimentacao_1",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_1_UsuarioId",
                table: "Movimentacao_1",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacao_1");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
