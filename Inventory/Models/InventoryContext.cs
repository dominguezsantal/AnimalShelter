using Microsoft.EntityFrameworkCore;


namespace Inventory.Models
{
  public class InventoryContext : DbContext
  {
    public DbSet<PetsCollection> PetsCollection { get; set; }
    public DbSet<Pet> Pet { get; set; }
  

    public InventoryContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}