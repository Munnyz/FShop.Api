using FShop.ProdutoApi.Context;
using FShop.ProdutoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FShop.ProdutoApi.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos.Include(c => c.Categoria).ToListAsync();
        }
        public async Task<Produto> GetById(int id)
        {
            return await _context.Produtos.Include(c => c.Categoria).Where(p => p.id == id)
            .FirstOrDefaultAsync();
        }
        public async Task<Produto> Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
        public async Task<Produto> Update(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return produto;
        }
        public async Task<Produto> Delete(int id)
        {
            var pr = await GetById(id);
            _context.Produtos.Remove(pr);
            await _context.SaveChangesAsync();
            return pr;
        }
        
    }
}
