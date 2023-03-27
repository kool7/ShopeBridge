using Microsoft.EntityFrameworkCore;
using ShopBridge.Modals;

namespace ShopBridge.Data;

public class ShopBridgeDbContext : DbContext
{

    public ShopBridgeDbContext(DbContextOptions<ShopBridgeDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products => Set<Product>();

}