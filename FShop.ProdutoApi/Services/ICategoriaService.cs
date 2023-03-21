using FShop.ProdutoApi.DTOs;

namespace FShop.ProdutoApi.Services;

public interface ICategoriaService
{
    Task<IEnumerable<CategoriaDTO>> GetCategorias();
    Task<IEnumerable<CategoriaDTO>> GetCategoriesProducts();
    Task<CategoriaDTO> GetCategoriaById(int id);
    Task AddCategoria(CategoriaDTO categoriaDto);
    Task UpdateCategoria(CategoriaDTO CategoriaDto);
    Task DeleteCategoria(int id);
}
