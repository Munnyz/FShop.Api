using FShop.ProdutoApi.Models;

namespace FShop.ProdutoApi.Repositories;

public interface ICategoriaRepository
{
    Task<IEnumerable<Categoria>> GetAll();
    Task<IEnumerable<Categoria>> GetCategoriesProducts();
    Task<Categoria> GetById(int id);
    Task<Categoria> Create(Categoria categoria);
    Task<Categoria> Update(Categoria categoria);
    Task<Categoria> Delete(int id);
    
}
