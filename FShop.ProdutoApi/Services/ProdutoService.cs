using AutoMapper;
using FShop.ProdutoApi.DTOs;
using FShop.ProdutoApi.Models;
using FShop.ProdutoApi.Repositories;

namespace FShop.ProdutoApi.Services;

public class ProdutoService : IProdutoService
{
    private readonly IMapper _mapper;
    private IProdutoRepository _productRepository;

    public ProdutoService(IMapper mapper, IProdutoRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<ProdutoDTO>> GetProducts()
    {
        var productsEntity = await _productRepository.GetAll();
        return _mapper.Map<IEnumerable<ProdutoDTO>>(productsEntity);
    }
    public async Task<ProdutoDTO> GetProductById(int id)
    {
        var productEntity = await _productRepository.GetById(id);
        return _mapper.Map<ProdutoDTO>(productEntity);
    }
    public async Task AddProduct(ProdutoDTO productDto)
    {
        var productEntity = _mapper.Map<Produto>(productDto);
        await _productRepository.Create(productEntity);
        productDto.id = productEntity.id;
    }
    public async Task UpdateProduct(ProdutoDTO productDto)
    {
        var categoryEntity = _mapper.Map<Produto>(productDto);
        await _productRepository.Update(categoryEntity);
    }
    public async Task RemoveProduct(int id)
    {
        var productEntity = await _productRepository.GetById(id);
        await _productRepository.Delete(productEntity.id);
    }
}
