using Microsoft.EntityFrameworkCore;

namespace EZLotteri.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Barn> Børn { get; set; }
        public DbSet<Bruger> Brugere { get; set; }
        public DbSet<BørneGruppe> Børnegruppe { get; set; }
        public DbSet<Leder> Ledere { get; set; }

        // Eventuelle yderligere DbSet-egenskaber for de andre klasser

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barn>().ToTable("Barn", schema: "dbo");
            modelBuilder.Entity<Bruger>().ToTable("Bruger", schema: "dbo");
            modelBuilder.Entity<BørneGruppe>().ToTable("BørneGruppe", schema: "dbo");
            modelBuilder.Entity<Leder>().ToTable("Leder", schema: "dbo");

            // Her kan man tilføje eventuelle konfigurationer for vores modeller
        }
    }
}