using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPSoft.DATA.Migrations
{
    /// <inheritdoc />
    public partial class OrdemServico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKOrdemCompraFornecedor",
                table: "OrdemCompra");

            migrationBuilder.DropForeignKey(
                name: "FKOrdemPedidoMaterial",
                table: "OrdemCompra");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrdemSer__3214EC0747752C80",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "StatusOC",
                table: "OrdemCompra");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "OrdemServico",
                type: "date",
                fixedLength: true,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrdemCom__3214EC0742F00992",
                table: "OrdemServico",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FKOrdemCompraFornecedor",
                table: "OrdemCompra",
                column: "IdOrdemFornecedor",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FKOrdemPedidoMaterial",
                table: "OrdemCompra",
                column: "IdOrdemPedidoMaterial",
                principalTable: "PedidoMaterial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FKOrdemCompraFornecedor",
                table: "OrdemCompra");

            migrationBuilder.DropForeignKey(
                name: "FKOrdemPedidoMaterial",
                table: "OrdemCompra");

            migrationBuilder.DropPrimaryKey(
                name: "PK__OrdemCom__3214EC0742F00992",
                table: "OrdemServico");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "OrdemServico",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldFixedLength: true);

            migrationBuilder.AddColumn<string>(
                name: "StatusOC",
                table: "OrdemCompra",
                type: "varchar(30)",
                unicode: false,
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK__OrdemSer__3214EC0747752C80",
                table: "OrdemServico",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FKOrdemCompraFornecedor",
                table: "OrdemCompra",
                column: "IdOrdemFornecedor",
                principalTable: "Fornecedor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FKOrdemPedidoMaterial",
                table: "OrdemCompra",
                column: "IdOrdemPedidoMaterial",
                principalTable: "PedidoMaterial",
                principalColumn: "Id");
        }
    }
}
