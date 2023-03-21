using FShop.ProdutoApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FShop.ProdutoApi.DTOs
{
    public class ProdutoDTO
    {
        public int id { get; set; }

        [Required(ErrorMessage = "O Nome é Obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O Preço é Obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Adescrição é Obrigatória")]
        [MinLength(5)]
        [MaxLength(300)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "O Stock é Obrigatório")]
        [Range(1, 9999)]
        public long Stock { get; set; }
        public string? ImageUrl { get; set; }

        public string? CategoriaName { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
