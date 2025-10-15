using Microsoft.EntityFrameworkCore;
using TesProgrammer.Models.DB;

namespace TesProgrammer.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Dosen> Dosens { get; set; }
        public DbSet<Matakuliah> MataKuliahs { get; set; }
        public DbSet<DosenMatakuliah> DosenMataKuliahs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DosenMatakuliah>()
                .HasOne(dm => dm.Dosen)
                .WithMany(d => d.DosenMataKuliahs)
                .HasForeignKey(dm => dm.DosenId);

            modelBuilder.Entity<DosenMatakuliah>()
                .HasOne(dm => dm.MataKuliah)
                .WithMany()
                .HasForeignKey(dm => dm.MataKuliahId);
        }
    }
}
