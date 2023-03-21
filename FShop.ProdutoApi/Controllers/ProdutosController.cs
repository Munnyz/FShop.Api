using FShop.ProdutoApi.DTOs;
using FShop.ProdutoApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FShop.ProdutoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _productService;
        public ProdutosController(IProdutoService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtosDto = await _productService.GetProducts();
            if (produtosDto == null)
            {
                return NotFound("Products not found");
            }
            return Ok(produtosDto);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            var produtoDto = await _productService.GetProductById(id);
            if (produtoDto == null)
            {
                return NotFound("Product not found");
            }
            return Ok(produtoDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Data Invalid");

            await _productService.AddProduct(produtoDto);

            return new CreatedAtRouteResult("GetProduct",
                new { id = produtoDto.id }, produtoDto);
        }

        [HttpPut()]
        public async Task<ActionResult> Put([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Data invalid");

            await _productService.UpdateProduct(produtoDto);

            return Ok(produtoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produtoDto = await _productService.GetProductById(id);

            if (produtoDto == null)
            {
                return NotFound("Product not found");
            }

            await _productService.RemoveProduct(id);

            return Ok(produtoDto);
        }
    }
}
