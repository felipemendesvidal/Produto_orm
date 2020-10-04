using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai_Aula6.Migrations
{
    public partial class AlterTableProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoItem_Pedido_PedidosId",
                table: "ProdutoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoItem_Produto_ProdutosId",
                table: "ProdutoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoItem",
                table: "ProdutoItem");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoItem_PedidosId",
                table: "ProdutoItem");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoItem_ProdutosId",
                table: "ProdutoItem");

            migrationBuilder.DropColumn(
                name: "IdProdutoItem",
                table: "ProdutoItem");

            migrationBuilder.DropColumn(
                name: "PedidosId",
                table: "ProdutoItem");

            migrationBuilder.DropColumn(
                name: "ProdutosId",
                table: "ProdutoItem");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProdutoItem",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "ProdutoItem",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UrlImagem",
                table: "Produto",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoItem",
                table: "ProdutoItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoItem_IdPedido",
                table: "ProdutoItem",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoItem_IdProduto",
                table: "ProdutoItem",
                column: "IdProduto");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoItem_Pedido_IdPedido",
                table: "ProdutoItem",
                column: "IdPedido",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoItem_Produto_IdProduto",
                table: "ProdutoItem",
                column: "IdProduto",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoItem_Pedido_IdPedido",
                table: "ProdutoItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoItem_Produto_IdProduto",
                table: "ProdutoItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoItem",
                table: "ProdutoItem");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoItem_IdPedido",
                table: "ProdutoItem");

            migrationBuilder.DropIndex(
                name: "IX_ProdutoItem_IdProduto",
                table: "ProdutoItem");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProdutoItem");

            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "ProdutoItem");

            migrationBuilder.DropColumn(
                name: "UrlImagem",
                table: "Produto");

            migrationBuilder.AddColumn<Guid>(
                name: "IdProdutoItem",
                table: "ProdutoItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PedidosId",
                table: "ProdutoItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutosId",
                table: "ProdutoItem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoItem",
                table: "ProdutoItem",
                column: "IdProdutoItem");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoItem_PedidosId",
                table: "ProdutoItem",
                column: "PedidosId");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoItem_ProdutosId",
                table: "ProdutoItem",
                column: "ProdutosId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoItem_Pedido_PedidosId",
                table: "ProdutoItem",
                column: "PedidosId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoItem_Produto_ProdutosId",
                table: "ProdutoItem",
                column: "ProdutosId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
