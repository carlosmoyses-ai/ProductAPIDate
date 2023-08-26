using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsAPI.Models;

public class Product
{
    public int ProductId { get; set; }

    [StringLength(100)]
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string? Name { get; set; }

    [Range(1, 1000)]
    [Required(ErrorMessage = "O preço é obrigatório")]   
    public decimal Price { get; set; }

    [Required(ErrorMessage = "A quantidade é obrigatória")]
    [Range(1, 1000)]
    public int Quantity { get; set; }
}