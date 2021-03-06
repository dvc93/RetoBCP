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

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Moneda> Moneda { get; set; }
        public virtual DbSet<TipoCambioMoneda> TipoCambioMoneda { get; set; }
        public virtual DbSet<TipoCambioPreferencial> TipoCambioPreferencials { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=DESKTOP-JV8KDIM;initial catalog=AppCambioDinero;user id=sa;password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__885457EE0E8C5ACD");

                entity.ToTable("Cliente", "GENERALES");

                entity.Property(e => e.IdCliente).HasColumnName("idCliente");

                entity.Property(e => e.ClientePreferencial).HasDefaultValueSql("((0))");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

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

                entity.Property(e => e.TipoCambio).HasColumnType("decimal(18, 3)");

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

            modelBuilder.Entity<TipoCambioPreferencial>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TipoCambioPreferencial", "GENERALES");

                entity.Property(e => e.MonedaDestino)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MonedaOrigen)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCambio).HasColumnType("decimal(18, 3)");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__Usuario__C9F2845718D9D079");

                entity.ToTable("Usuario", "GENERALES");

                entity.Property(e => e.UserName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Token).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
