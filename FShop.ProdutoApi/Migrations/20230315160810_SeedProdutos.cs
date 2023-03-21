using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FShop.ProdutoApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(Nome, Preco, Descricao, Stock, ImageUrl, CategoriaId)" +
                "Values('Caderno',7.23,'Caderno',10,'caderno1.jpg',1)");
            mb.Sql("Insert into Produtos(Nome, Preco, Descricao, Stock, ImageUrl, CategoriaId)" +
                "Values('Lapis',2.23,'Lapis',40,'lapis1.jpg',1)");
            mb.Sql("Insert into Produtos(Nome, Preco, Descricao, Stock, ImageUrl, CategoriaId)" +
                "Values('Clips',1.03,'clips',100,'clips1.jpg',2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
