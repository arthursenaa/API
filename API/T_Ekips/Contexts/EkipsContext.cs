using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace $safeprojectname$.Domains
{
    public partial class EkipsContext : DbContext
    {
        public EkipsContext()
        {
        }

        public EkipsContext(DbContextOptions<EkipsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ativo> Ativo { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost; Initial Catalog=T_Ekips;User Id=sa;Pwd=132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ativo>(entity =>
            {
                entity.HasKey(e => e.IdAtividade);

                entity.HasIndex(e => e.Ativo1)
                    .HasName("UQ__Ativo__2D26FD55F8688D83")
                    .IsUnique();

                entity.Property(e => e.Ativo1)
                    .IsRequired()
                    .HasColumnName("Ativo")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo);

                entity.HasIndex(e => e.Cargo1)
                    .HasName("UQ__Cargo__68A1C0DFDC726FFA")
                    .IsUnique();

                entity.Property(e => e.Cargo1)
                    .IsRequired()
                    .HasColumnName("Cargo")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAtivoNavigation)
                    .WithMany(p => p.Cargo)
                    .HasForeignKey(d => d.IdAtivo)
                    .HasConstraintName("FK__Cargo__IdAtivo__60A75C0F");
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento);

                entity.HasIndex(e => e.Departamento1)
                    .HasName("UQ__Departam__71BEBBD72F9BC8B4")
                    .IsUnique();

                entity.Property(e => e.Departamento1)
                    .IsRequired()
                    .HasColumnName("Departamento")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Funciona__C1F89731A5A5292F")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.IdCargo)
                    .HasConstraintName("FK__Funcionar__IdCar__656C112C");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__Funcionar__IdDep__6477ECF3");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Funcionario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Funcionar__IdUsu__66603565");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.HasKey(e => e.IdPermissao);

                entity.Property(e => e.Permissao1)
                    .IsRequired()
                    .HasColumnName("Permissao")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuario__A9D1053457606890")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPermissaoNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPermissao)
                    .HasConstraintName("FK__Usuario__IdPermi__4CA06362");
            });
        }
    }
}
