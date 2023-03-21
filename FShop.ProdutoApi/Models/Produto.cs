namespace FShop.ProdutoApi.Models;
public class Produto
{
    public int id { get; set; }
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
    public string? Descricao { get; set; }
    public long Stock { get; set; }
    public string? ImageUrl { get; set; }

    public Categoria? Categoria { get; set; }
    public int CategoriaId { get; set; }
}
