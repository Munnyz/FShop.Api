using FShop.ProdutoApi.DTOs;

namespace FShop.ProdutoApi.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProducts();
        Task<ProdutoDTO> GetProductById(int id);
        Task AddProduct(ProdutoDTO productDto);
        Task UpdateProduct(ProdutoDTO productDto);
        Task RemoveProduct(int id);
    }
}
