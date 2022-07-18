using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Webshop_WPF.Stores;

#nullable disable

namespace Webshop_WPF.Models
{
    public partial class webaruhazContext : DbContext
    {
        public webaruhazContext()
        {
        }

        public webaruhazContext(DbContextOptions<webaruhazContext> options)
            : base(options)
        {
        }

        public virtual DbSet<admin> admin { get; set; }
        public virtual DbSet<rendeles> rendeles { get; set; }
        public virtual DbSet<rendelesi_tetelek> rendelesi_tetelek { get; set; }
        public virtual DbSet<termek> termek { get; set; }
        public virtual DbSet<vasarlo> vasarlo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                string connectionString = string.Empty;
                if (RunEnviroment.IsTestEnviroment)
                    connectionString = "server=localhost;user id=root;database=webaruhazwpf_teszt";
                else
                    connectionString = ConfigurationManager.ConnectionStrings["WebaruhazDB"].ConnectionString;
                optionsBuilder.UseMySql(connectionString, ServerVersion.Parse("10.4.22-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            modelBuilder.Entity<admin>(entity =>
            {
                entity.HasCharSet("utf8")
                    .UseCollation("utf8_hungarian_ci");

                entity.Property(e => e.id).ValueGeneratedNever();
            });

            modelBuilder.Entity<rendeles>(entity =>
            {
                entity.HasKey(e => e.Rendeles_id)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_hungarian_ci");

                entity.HasOne(d => d.Vasarlo)
                    .WithMany(p => p.rendeles)
                    .HasForeignKey(d => d.Vasarlo_id)
                    .HasConstraintName("rendeles_ibfk_1");
            });

            modelBuilder.Entity<rendelesi_tetelek>(entity =>
            {
                entity.HasKey(e => e.Rendelesi_tetelek_id)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_hungarian_ci");

                entity.HasOne(d => d.CikkszamNavigation)
                    .WithMany(p => p.rendelesi_tetelek)
                    .HasForeignKey(d => d.Cikkszam)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rendelesi_tetelek_ibfk_2");

                entity.HasOne(d => d.Rendeles)
                    .WithMany(p => p.rendelesi_tetelek)
                    .HasForeignKey(d => d.Rendeles_id)
                    .HasConstraintName("rendelesi_tetelek_ibfk_1");
            });

            modelBuilder.Entity<termek>(entity =>
            {
                entity.HasKey(e => e.Cikkszam)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_hungarian_ci");

                entity.Property(e => e.Cikkszam).ValueGeneratedNever();
            });

            modelBuilder.Entity<vasarlo>(entity =>
            {
                entity.HasKey(e => e.Vasarlo_id)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_hungarian_ci");

                entity.Property(e => e.Vasarlo_id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
