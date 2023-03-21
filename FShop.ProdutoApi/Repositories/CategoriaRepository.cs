using FShop.ProdutoApi.Context;
using FShop.ProdutoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FShop.ProdutoApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
           return await _context.Categorias.ToListAsync();
        }
        public async Task<IEnumerable<Categoria>> GetCategoriesProducts()
        {
            return await _context.Categorias.Include(c=> c.Produtos).ToListAsync();
        }
        public async Task<Categoria> GetById(int id)
        {
            return await _context.Categorias.Where(c=> c.CategoriaId == id).FirstOrDefaultAsync();
        }
        public async Task<Categoria> Create(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }
        public async Task<Categoria> Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return categoria;
        }
        public async Task<Categoria> Delete(int id)
        {
            var fu = await GetById(id);
            _context.Categorias.Remove(fu);
            await _context.SaveChangesAsync();
             return fu;
        }
    }
}
