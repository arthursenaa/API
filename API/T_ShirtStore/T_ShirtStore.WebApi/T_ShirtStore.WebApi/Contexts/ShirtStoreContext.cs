using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace T_ShirtStore.WebApi.Domains
{
    public partial class ShirtStoreContext : DbContext
    {
        public ShirtStoreContext()
        {
        }

        public ShirtStoreContext(DbContextOptions<ShirtStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Camisa> Camisa { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Estoque> Estoque { get; set; }
        public virtual DbSet<Perfis> Perfis { get; set; }
        public virtual DbSet<Tamanho> Tamanho { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=T_ShirtStore;User Id=sa;Pwd=132;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camisa>(entity =>
            {
                entity.HasKey(e => e.IdCamisa);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            

            modelBuilder.Entity<Estoque>(entity =>
            {
                entity.HasKey(e => e.IdEstoque);

                entity.Property(e => e.Cor)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.CamisaNavigation)
                    .WithMany(p => p.Estoque)
                    .HasForeignKey(d => d.Camisa)
                    .HasConstraintName("FK__Estoque__Camisa__5165187F");

                entity.HasOne(d => d.TamanhoNavigation)
                    .WithMany(p => p.Estoque)
                    .HasForeignKey(d => d.Tamanho)
                    .HasConstraintName("FK__Estoque__Tamanho__52593CB8");
            });

            modelBuilder.Entity<Perfis>(entity =>
            {
                entity.HasKey(e => e.IdPerfil);

                entity.HasIndex(e => e.Perfil)
                    .HasName("UQ__Perfis__277B0CDC8C1B6E9F")
                    .IsUnique();

                entity.Property(e => e.Perfil)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tamanho>(entity =>
            {
                entity.HasKey(e => e.IdTamanho);

                entity.HasIndex(e => e.Tamanho1)
                    .HasName("UQ__Tamanho__51586FB10650D55C")
                    .IsUnique();

                entity.Property(e => e.Tamanho1)
                    .IsRequired()
                    .HasColumnName("Tamanho")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D10534DF514E4F")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdEmpresa)
                    .HasConstraintName("FK__Usuario__IdEmpre__5FB337D6");
            });
        }
    }
}
