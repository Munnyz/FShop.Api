using FShop.ProdutoApi.DTOs;
using FShop.ProdutoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FShop.ProdutoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriasService;

    public CategoriasController(ICategoriaService categoriasService)
    {
        _categoriasService = categoriasService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
    {
        var categoriasDto = await _categoriasService.GetCategorias();

        if (categoriasDto is null)        
            return NotFound("Categorias Not Found");

        return Ok(categoriasDto);
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategoriasProducts()
    {
        var categoriesDto = await _categoriasService.GetCategoriesProducts();
        if (categoriesDto == null)
        {
            return NotFound("Categories not found");
        }
        return Ok(categoriesDto);
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<CategoriaDTO>> Get(int id)
    {
        var categoryDto = await _categoriasService.GetCategoriaById(id);
        if (categoryDto == null)
        {
            return NotFound("Category not found");
        }
        return Ok(categoryDto);
    }
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoriaDTO categoryDto)
    {
        if (categoryDto == null)
            return BadRequest("Invalid Data");

        await _categoriasService.AddCategoria(categoryDto);

        return new CreatedAtRouteResult("GetCategory", new { id = categoryDto.CategoriaId },
            categoryDto);
    }
    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoryDto)
    {
        if (id != categoryDto.CategoriaId)
            return BadRequest();

        if (categoryDto is null)
            return BadRequest();

        await _categoriasService.UpdateCategoria(categoryDto);

        return Ok(categoryDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<CategoriaDTO>> Delete(int id)
    {
        var categoryDto = await _categoriasService.GetCategoriaById(id);
        if (categoryDto == null)
        {
            return NotFound("Category not found");
        }

        await _categoriasService.GetCategoriaById(id);

        return Ok(categoryDto);
    }

}
