using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APINetCore.Persistence.Migrations
{
    public partial class PrimeiroMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comandas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusComanda = table.Column<int>(nullable: false),
                    dtAbertura = table.Column<DateTime>(nullable: false),
                    dtFechamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comandas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotasFiscais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdComanda = table.Column<int>(nullable: false),
                    dtEmissao = table.Column<DateTime>(nullable: false),
                    valorTotal = table.Column<double>(nullable: false),
                    valorDesconto = table.Column<double>(nullable: false),
                    valorPago = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    ValorUnitario = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComandaItens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdComanda = table.Column<int>(nullable: false),
                    IdProduto = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: true),
                    quantidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComandaItens_Comandas_IdComanda",
                        column: x => x.IdComanda,
                        principalTable: "Comandas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComandaItens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotasFiscaisItens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(nullable: false),
                    ValorTotalItem = table.Column<double>(nullable: false),
                    ValorDesconto = table.Column<double>(nullable: false),
                    ValorComDesconto = table.Column<double>(nullable: false),
                    IdNotaFiscal = table.Column<int>(nullable: false),
                    IdProduto = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasFiscaisItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasFiscaisItens_NotasFiscais_IdNotaFiscal",
                        column: x => x.IdNotaFiscal,
                        principalTable: "NotasFiscais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotasFiscaisItens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IdUnidade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professores_Unidades_IdUnidade",
                        column: x => x.IdUnidade,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IdUnidade = table.Column<int>(nullable: false),
                    IdProfessor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Professores_IdProfessor",
                        column: x => x.IdProfessor,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alunos_Unidades_IdUnidade",
                        column: x => x.IdUnidade,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdProfessor",
                table: "Alunos",
                column: "IdProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_IdUnidade",
                table: "Alunos",
                column: "IdUnidade");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaItens_IdComanda",
                table: "ComandaItens",
                column: "IdComanda");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaItens_ProdutoId",
                table: "ComandaItens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscaisItens_IdNotaFiscal",
                table: "NotasFiscaisItens",
                column: "IdNotaFiscal");

            migrationBuilder.CreateIndex(
                name: "IX_NotasFiscaisItens_ProdutoId",
                table: "NotasFiscaisItens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Professores_IdUnidade",
                table: "Professores",
                column: "IdUnidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "ComandaItens");

            migrationBuilder.DropTable(
                name: "NotasFiscaisItens");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.DropTable(
                name: "Comandas");

            migrationBuilder.DropTable(
                name: "NotasFiscais");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Unidades");
        }
    }
}
