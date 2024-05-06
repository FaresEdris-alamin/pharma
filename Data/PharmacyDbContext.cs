using Microsoft.EntityFrameworkCore;
using pharmacy.Model;

namespace pharmacy.Data;

public class PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : DbContext(options)
{
    public DbSet<Medicine> Medicines => Set<Medicine>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelbuilder){
        modelbuilder.Entity<Category>().HasData(
            new{Id =1,Name ="cough"},
            new{Id =2,Name ="headache"},
            new{Id =3,Name ="covid"},
            new{Id =4,Name ="pain"},
            new{Id =5,Name ="elxir"}
        );
    }
}
