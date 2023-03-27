using ShopBridge.Modals;

namespace ShopBridge.Contracts.Products;

public interface IProductRepository
{
    Task<Product> GetProductById(int Id);
    Task<IEnumerable<Product>> GetProducts();
    Task CreateProduct(Product product);
    void DeleteProduct(Product product);
    Task SaveChanges();
}