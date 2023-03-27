namespace ShopBridge.Contracts.Products;

public class UpdateProductDto
{
    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int Units { get; set; }

    public bool IsAvailable { get; set; }
}