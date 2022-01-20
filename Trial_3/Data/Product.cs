namespace Trial_3.Data;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Product
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    [Required]
    public string Name { get; set; } = String.Empty;
    [Required, Precision(8,2)]
    public decimal Price { get; set; } = 0m;

    public decimal CalculateFinalPrice(int age) => age switch
    {
        <12     => Price * 0.5m,
        >=65    => Price * 0.8m,
        _       => Price
    };
}