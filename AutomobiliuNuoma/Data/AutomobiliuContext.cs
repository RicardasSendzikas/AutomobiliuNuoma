using Microsoft.EntityFrameworkCore;

namespace AutomobiliuNuoma.Data
{
    public class AutomobiliuContext : DbContext
    {
        public AutomobiliuContext(DbContextOptions<AutomobiliuContext> options) : base(options)
        {
        }

        public DbSet<Automobilis> Automobiliai { get; set; }
        public DbSet<Darbuotojas> Darbuotojai { get; set; }
        public DbSet<Klientas> Klientai { get; set; }
        public DbSet<NuomosUzsakymas> NuomosUzsakymai { get; set; }

        // Papildomai, galite pridėti metodą, kad konfigūruotumėte modelius
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NaftosAutomobilis>().ToTable("NaftosAutomobiliai");
            modelBuilder.Entity<ElektrinisAutomobilis>().ToTable("ElektriniaiAutomobiliai");
            // Papildomi konfigūravimai, jei reikia
        }
    }
}