using Microsoft.EntityFrameworkCore;
using FShop.ProdutoApi.Models;

namespace FShop.ProdutoApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        //Fluent Api
        protected override void OnModelCreating(ModelBuilder mb)
        {
            //categoria
            mb.Entity<Categoria>().HasKey(c => c.CategoriaId);

            mb.Entity<Categoria>().
                Property(c => c.Nome).
                HasMaxLength(100).
                IsRequired();

            //produto
            mb.Entity<Produto>().
                Property(c => c.Nome).
                HasMaxLength(100).
                IsRequired();

            mb.Entity<Produto>().
                Property(c => c.Descricao).
                HasMaxLength(200).
                IsRequired();

            mb.Entity<Produto>().
                Property(c => c.ImageUrl).
                HasMaxLength(200).
                IsRequired();

            mb.Entity<Produto>().
                Property(c => c.Preco).
                HasPrecision(12, 2);

            mb.Entity<Categoria>().
                HasMany(g => g.Produtos).
                WithOne(c => c.Categoria).
                IsRequired().
                    OnDelete(DeleteBehavior.Cascade);

            mb.Entity<Categoria>().HasData(
                new Categoria
                {
                    CategoriaId = 1,
                    Nome = "Material escolar",
                },
                new Categoria
                {
                    CategoriaId = 2,
                    Nome = "Acessorios escolar",
                }
                );
        }
    }
}
