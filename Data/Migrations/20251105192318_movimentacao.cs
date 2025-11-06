using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EstoqueEquipEletro.Data.Migrations
{
    /// <inheritdoc />
    public partial class movimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateMovimentação",
                table: "Movimentacao_1");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Movimentacao_1",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Movimentacao_1");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateMovimentação",
                table: "Movimentacao_1",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
