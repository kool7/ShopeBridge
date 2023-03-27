using Microsoft.EntityFrameworkCore;
using ShopBridge.Contracts.Products;
using ShopBridge.Data;
using ShopBridge.Modals;

namespace ShopBridge.Services;

public class ProductRepository : IProductRepository
{
    private readonly ShopBridgeDbContext _context;

    public ProductRepository(ShopBridgeDbContext context)
    {
        _context = context;
    }

    public async Task CreateProduct(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        await _context.AddAsync(product);
    }

    public void DeleteProduct(Product product)
    {
        if (product == null) throw new ArgumentNullException(nameof(product));
        _context.Remove(product);
    }

    public async Task<Product?> GetProductById(int Id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == Id);
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}