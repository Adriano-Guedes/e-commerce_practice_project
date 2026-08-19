using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Infrastructure.Data.Context;

public partial class EcommerceDbContext : DbContext
{
    public EcommerceDbContext()
    {
    }

    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<ProdutosPedido> ProdutosPedidos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorias_pkey");

            entity.ToTable("categorias");

            entity.HasIndex(e => e.Nome, "categorias_nome_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataAtualizacao).HasColumnName("data_atualizacao");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("now()")
                .HasColumnName("data_criacao");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pedidos_pkey");

            entity.ToTable("pedidos");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.ChaveUsuario).HasColumnName("chave_usuario");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("now()")
                .HasColumnName("data_criacao");
            entity.Property(e => e.PrecoTotal)
                .HasPrecision(10, 2)
                .HasColumnName("preco_total");

            entity.HasOne(d => d.ChaveUsuarioNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.ChaveUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_pedidos_usuarios");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("produtos_pkey");

            entity.ToTable("produtos");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");
            entity.Property(e => e.DataAtualizacao).HasColumnName("data_atualizacao");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("now()")
                .HasColumnName("data_criacao");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
            entity.Property(e => e.Nome)
                .HasMaxLength(200)
                .HasColumnName("nome");
            entity.Property(e => e.NomeArquivoImagem)
                .HasComment("Referência do arquivo no S3")
                .HasColumnName("nome_arquivo_imagem");
            entity.Property(e => e.Preco)
                .HasPrecision(10, 2)
                .HasColumnName("preco");
            entity.Property(e => e.QuantidadeEstoque)
                .HasDefaultValue(0)
                .HasColumnName("quantidade_estoque");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produtos_categorias");
        });

        modelBuilder.Entity<ProdutosPedido>(entity =>
        {
            entity.HasKey(e => new { e.ChavePedido, e.ChaveProduto }).HasName("produtos_pedidos_pkey");

            entity.ToTable("produtos_pedidos");

            entity.Property(e => e.ChavePedido).HasColumnName("chave_pedido");
            entity.Property(e => e.ChaveProduto).HasColumnName("chave_produto");
            entity.Property(e => e.PrecoUnitario)
                .HasPrecision(10, 2)
                .HasComment("Preço congelado no momento da compra")
                .HasColumnName("preco_unitario");
            entity.Property(e => e.QuantidadeProduto).HasColumnName("quantidade_produto");

            entity.HasOne(d => d.ChavePedidoNavigation).WithMany(p => p.ProdutosPedidos)
                .HasForeignKey(d => d.ChavePedido)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produtos_pedidos_pedidos");

            entity.HasOne(d => d.ChaveProdutoNavigation).WithMany(p => p.ProdutosPedidos)
                .HasForeignKey(d => d.ChaveProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_produtos_pedidos_produtos");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.HasIndex(e => e.Cpf, "usuarios_cpf_key").IsUnique();

            entity.HasIndex(e => e.Email, "usuarios_email_key").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.Cpf)
                .HasMaxLength(14)
                .HasComment("Opcional / Único se preenchido")
                .HasColumnName("cpf");
            entity.Property(e => e.DataAtualizacao).HasColumnName("data_atualizacao");
            entity.Property(e => e.DataCriacao)
                .HasDefaultValueSql("now()")
                .HasColumnName("data_criacao");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Nome)
                .HasMaxLength(150)
                .HasColumnName("nome");
            entity.Property(e => e.NomeArquivoImagem)
                .HasComment("Referência do arquivo no S3")
                .HasColumnName("nome_arquivo_imagem");
            entity.Property(e => e.Papel)
                .HasMaxLength(50)
                .HasDefaultValueSql("'cliente'::character varying")
                .HasColumnName("papel");
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .HasColumnName("senha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
