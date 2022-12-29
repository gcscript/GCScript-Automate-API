using Microsoft.EntityFrameworkCore;
using GCScript_Automate_API.Models;
using GCScript_Automate_API.Data.Mappings;

namespace GCScript_Automate_API.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

    public DbSet<CategoryModel>? Categories { get; set; }
    public DbSet<TypeModel>? Types { get; set; }
    public DbSet<SubtypeModel>? Subtypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new TypeMap());
        modelBuilder.ApplyConfiguration(new SubtypeMap());
    }
}
