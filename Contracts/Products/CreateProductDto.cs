namespace ShopBridge.Contracts.Products;

public class CreateProductDto
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int Units { get; set; }

    public bool IsAvailable { get; set; }

}