using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BiBliotecaUser.ORM1;

public partial class BibliotecaContext : DbContext
{
    public BibliotecaContext()
    {
    }

    public BibliotecaContext(DbContextOptions<BibliotecaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCategoria> TbCategorias { get; set; }

    public virtual DbSet<TbEmprestimo> TbEmprestimos { get; set; }

    public virtual DbSet<TbFuncionario> TbFuncionarios { get; set; }

    public virtual DbSet<TbLivro> TbLivros { get; set; }

    public virtual DbSet<TbMembro> TbMembros { get; set; }

    public virtual DbSet<TbReserva> TbReservas { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAB205_2\\SQLEXPRESS;Database=Biblioteca;User Id=BiBliotecaUser;Password=admin742;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCategoria>(entity =>
        {
            entity.ToTable("Tb_Categorias");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descricao).HasColumnType("text");
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbEmprestimo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Tb_Emprestimo");

            entity.ToTable("Tb_Emprestimos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataDevolucao).HasColumnType("datetime");
            entity.Property(e => e.DataEmprestimo).HasColumnType("datetime");

            entity.HasOne(d => d.FkLivroNavigation).WithMany(p => p.TbEmprestimos)
                .HasForeignKey(d => d.FkLivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tb_Emprestimos_Tb_Livros");

            entity.HasOne(d => d.FkMembroNavigation).WithMany(p => p.TbEmprestimos)
                .HasForeignKey(d => d.FkMembro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tb_Emprestimos_Tb_Membros");
        });

        modelBuilder.Entity<TbFuncionario>(entity =>
        {
            entity.ToTable("Tb_Funcionarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbLivro>(entity =>
        {
            entity.ToTable("Tb_Livros");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AnoPubicacao).HasColumnType("datetime");
            entity.Property(e => e.Autor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.FkCategoriaNavigation).WithMany(p => p.TbLivros)
                .HasForeignKey(d => d.FkCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tb_Livros_Tb_Categorias");
        });

        modelBuilder.Entity<TbMembro>(entity =>
        {
            entity.ToTable("Tb_Membros");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataCadastro).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TipoMembro)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbReserva>(entity =>
        {
            entity.ToTable("Tb_Reservas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataReserva).HasColumnType("datetime");

            entity.HasOne(d => d.FkLivroNavigation).WithMany(p => p.TbReservas)
                .HasForeignKey(d => d.FkLivro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tb_Reservas_Tb_Livros");

            entity.HasOne(d => d.FkMembroNavigation).WithMany(p => p.TbReservas)
                .HasForeignKey(d => d.FkMembro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tb_Reservas_Tb_Membros");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.ToTable("Tb_Usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Senha)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
