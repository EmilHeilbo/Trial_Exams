namespace Trial_3.Models;

using Trial_3.Data;

public class ProductsViewModel
{
    public IEnumerable<Product> Products { get; set; } = default!;
    public decimal Total { get; set; } = 0m;
}