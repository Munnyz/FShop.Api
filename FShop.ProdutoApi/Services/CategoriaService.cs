using AutoMapper;
using FShop.ProdutoApi.Context;
using FShop.ProdutoApi.DTOs;
using FShop.ProdutoApi.Models;
using FShop.ProdutoApi.Repositories;

namespace FShop.ProdutoApi.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categoriasEntity = await _categoriaRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }
        public async Task<IEnumerable<CategoriaDTO>> GetCategoriesProducts()
        {
            var categoriasEntity = await _categoriaRepository.GetCategoriesProducts();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categoriasEntity);
        }
        public async Task<CategoriaDTO> GetCategoriaById(int id)
        {
            var categoriasEntity = await _categoriaRepository.GetById(id);
            return _mapper.Map<CategoriaDTO>(categoriasEntity); 
        }
       
        public async Task AddCategoria(CategoriaDTO categoriaDto)
        {
            var categoryEntity = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.Create(categoryEntity);
            categoriaDto.CategoriaId = categoryEntity.CategoriaId;
        }
        public async Task UpdateCategoria(CategoriaDTO categoriaDto)
        {
            var categoryEntity = _mapper.Map<Categoria>(categoriaDto);
            await _categoriaRepository.Update(categoryEntity);
        }
        public async Task DeleteCategoria(int id)
        {
            var categoryEntity = _categoriaRepository.GetById(id).Result;
            await _categoriaRepository.Delete(categoryEntity.CategoriaId);
        }
    }
}
