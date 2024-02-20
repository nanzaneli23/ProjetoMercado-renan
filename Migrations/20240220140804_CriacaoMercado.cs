using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMercado.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoMercado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id_Categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id_Categoria);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefoneCliente = table.Column<int>(type: "int", nullable: false),
                    CPFCliente = table.Column<int>(type: "int", nullable: false),
                    NumeroDoCartao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Id_Fornecedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CnpjFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Id_Fornecedor);
                });

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    Id_Pagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.Id_Pagamento);
                });

            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    Id_Vendedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeVendedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDoCaixa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.Id_Vendedor);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id_Produto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoProduto = table.Column<double>(type: "float", nullable: false),
                    QuantidadeEstoqueProduto = table.Column<int>(type: "int", nullable: false),
                    NumeroDoCodigo = table.Column<int>(type: "int", nullable: false),
                    Id_Categoria = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: true),
                    Id_Fornecedor = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id_Produto);
                    table.ForeignKey(
                        name: "FK_Produto_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id_Categoria");
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedor",
                        principalColumn: "Id_Fornecedor");
                });

            migrationBuilder.CreateTable(
                name: "Venda",
                columns: table => new
                {
                    Id_Venda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorTotal = table.Column<double>(type: "float", nullable: false),
                    DataVenda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    Id_Vendedor = table.Column<int>(type: "int", nullable: false),
                    VendedorId = table.Column<int>(type: "int", nullable: true),
                    Id_Pagamento = table.Column<int>(type: "int", nullable: false),
                    PagamentoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venda", x => x.Id_Venda);
                    table.ForeignKey(
                        name: "FK_Venda_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id_Cliente");
                    table.ForeignKey(
                        name: "FK_Venda_Pagamento_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "Pagamento",
                        principalColumn: "Id_Pagamento");
                    table.ForeignKey(
                        name: "FK_Venda_Vendedor_VendedorId",
                        column: x => x.VendedorId,
                        principalTable: "Vendedor",
                        principalColumn: "Id_Vendedor");
                });

            migrationBuilder.CreateTable(
                name: "VendasHasProduto",
                columns: table => new
                {
                    VendasHasProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendaId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeVendaHas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendasHasProduto", x => x.VendasHasProdutoId);
                    table.ForeignKey(
                        name: "FK_VendasHasProduto_Produto_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produto",
                        principalColumn: "Id_Produto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendasHasProduto_Venda_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Venda",
                        principalColumn: "Id_Venda",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CategoriaId",
                table: "Produto",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_FornecedorId",
                table: "Produto",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_ClienteId",
                table: "Venda",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_PagamentoId",
                table: "Venda",
                column: "PagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Venda_VendedorId",
                table: "Venda",
                column: "VendedorId");

            migrationBuilder.CreateIndex(
                name: "IX_VendasHasProduto_ProdutoId",
                table: "VendasHasProduto",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendasHasProduto_VendaId",
                table: "VendasHasProduto",
                column: "VendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendasHasProduto");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Venda");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Fornecedor");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
