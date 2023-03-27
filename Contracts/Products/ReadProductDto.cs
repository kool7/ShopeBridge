namespace ShopBridge.Contracts.Products;

public class ReadProductDto
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int Units { get; set; }

    public bool IsAvailable { get; set; }

}