using FShop.ProdutoApi.Models;
using System.ComponentModel.DataAnnotations;

namespace FShop.ProdutoApi.DTOs;
public class CategoriaDTO
{
    public int CategoriaId { get; set; }

    [Required(ErrorMessage = "O Nome é Obrigatório")]
    [MinLength(2)]
    [MaxLength(100)]
    public string? Nome { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
}
