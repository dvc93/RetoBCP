using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Domain.Models
{
    public partial class AppCambioDineroContext : DbContext
    {
        public AppCambioDineroContext()
        {
        }

        public AppCambioDineroContext(DbContextOptions<AppCambioDineroContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Moneda> Moneda { get; set; }
        public virtual DbSet<TipoCambioMoneda> TipoCambioMoneda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JV8KDIM;Database=AppCambioDinero;User ID=sa;Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.HasKey(e => e.CodigoMoneda)
                    .HasName("PK_MONEDA");

                entity.ToTable("Moneda", "GENERALES");

                entity.Property(e => e.CodigoMoneda)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AuditoriaFechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FlagActivo).HasDefaultValueSql("((1))");

                entity.Property(e => e.NombreMoneda)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoCambioMoneda>(entity =>
            {
                entity.HasKey(e => new { e.MonedaOrigen, e.MonedaDestino })
                    .HasName("PK_TIPOCAMBIO");

                entity.ToTable("TipoCambioMoneda", "GENERALES");

                entity.Property(e => e.MonedaOrigen)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MonedaDestino)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AuditoriaFechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AuditoriaFechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.FlagActivo)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdTipoCambio).ValueGeneratedOnAdd();

                entity.Property(e => e.TipoCambio).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.MonedaDestinoNavigation)
                    .WithMany(p => p.TipoCambioMonedumMonedaDestinoNavigations)
                    .HasForeignKey(d => d.MonedaDestino)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIPOCAMBIOMONEDA_MONEDA_MonedaDestino");

                entity.HasOne(d => d.MonedaOrigenNavigation)
                    .WithMany(p => p.TipoCambioMonedumMonedaOrigenNavigations)
                    .HasForeignKey(d => d.MonedaOrigen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TIPOCAMBIOMONEDA_MONEDA_MonedaOrigen");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
