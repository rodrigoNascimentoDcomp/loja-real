using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataAccess.Models
{
    public partial class LojaContext : DbContext
    {
        public LojaContext()
        {
        }

        public LojaContext(DbContextOptions<LojaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boleto> Boletos { get; set; }
        public virtual DbSet<CartaoCredito> CartaoCreditos { get; set; }
        public virtual DbSet<Catalogo> Catalogos { get; set; }
        public virtual DbSet<CategoriaLoja> CategoriaLojas { get; set; }
        public virtual DbSet<CategoriaProduto> CategoriaProdutos { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<CompraStatus> CompraStatuses { get; set; }
        public virtual DbSet<Comprador> Compradors { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<FormasDePagamento> FormasDePagamentos { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Loja> Lojas { get; set; }
        public virtual DbSet<Pagamento> Pagamentos { get; set; }
        public virtual DbSet<Pix> Pixes { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Promocao> Promocaos { get; set; }
        public virtual DbSet<SolicitaCadastro> SolicitaCadastros { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<StatusItem> StatusItems { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioSistema> UsuarioSistemas { get; set; }
        public virtual DbSet<UsuarioSistemaCategorium> UsuarioSistemaCategoria { get; set; }
        public virtual DbSet<UsuarioUsuarioSistema> UsuarioUsuarioSistemas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("name=Debug");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boleto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("boleto");

                entity.HasIndex(e => e.Numero, "numero_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("numero");
            });

            modelBuilder.Entity<CartaoCredito>(entity =>
            {
                entity.ToTable("cartao_credito");

                entity.HasIndex(e => e.Numero, "numero_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Cpf).HasColumnName("cpf");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("numero");

                entity.Property(e => e.Titular)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("titular");
            });

            modelBuilder.Entity<Catalogo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("catalogo");

                entity.HasIndex(e => e.LojaCnpj, "fk_catalogo_loja_idx");

                entity.HasIndex(e => e.ProdutoId, "fk_catalogo_produto_idx");

                entity.Property(e => e.Detalhes)
                    .HasMaxLength(45)
                    .HasColumnName("detalhes");

                entity.Property(e => e.LojaCnpj)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("loja_cnpj");

                entity.Property(e => e.Preco)
                    .HasColumnType("decimal(10,0)")
                    .HasColumnName("preco");

                entity.Property(e => e.ProdutoId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("produto_id");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("int unsigned")
                    .HasColumnName("quantidade");

                entity.HasOne(d => d.LojaCnpjNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.LojaCnpj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_catalogo_loja");

                entity.HasOne(d => d.Produto)
                    .WithMany()
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_catalogo_produto");
            });

            modelBuilder.Entity<CategoriaLoja>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("categoria_loja");

                entity.HasIndex(e => e.CateogriaId, "fk_categoria_loja_categoria_idx");

                entity.HasIndex(e => e.LojaCnpj, "fk_categoria_loja_loja_idx");

                entity.Property(e => e.CateogriaId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("cateogria_id");

                entity.Property(e => e.LojaCnpj)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("loja_cnpj");

                entity.HasOne(d => d.Cateogria)
                    .WithMany()
                    .HasForeignKey(d => d.CateogriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categoria_loja_categoria");

                entity.HasOne(d => d.LojaCnpjNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.LojaCnpj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categoria_loja_loja");
            });

            modelBuilder.Entity<CategoriaProduto>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("categoria_produto");

                entity.HasIndex(e => e.ProdutoId, "fk_categoria_produto_idx");

                entity.HasIndex(e => e.CategoriaId, "fk_produto_categoria_idx");

                entity.Property(e => e.CategoriaId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("categoria_id");

                entity.Property(e => e.ProdutoId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("produto_id");

                entity.HasOne(d => d.Categoria)
                    .WithMany()
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_categoria");

                entity.HasOne(d => d.Produto)
                    .WithMany()
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categoria_produto");
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.ToTable("compra");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.ValorTotal)
                    .HasColumnType("decimal(6,2)")
                    .HasColumnName("valor_total");
            });

            modelBuilder.Entity<CompraStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("compra_status");

                entity.HasIndex(e => e.CompraId, "compra_id_idx");

                entity.HasIndex(e => e.StatusId, "status_id_idx");

                entity.Property(e => e.CompraId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("compra_id");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.StatusId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("status_id");

                entity.HasOne(d => d.Compra)
                    .WithMany()
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("compra_id");

                entity.HasOne(d => d.Status)
                    .WithMany()
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("status_id");
            });

            modelBuilder.Entity<Comprador>(entity =>
            {
                entity.HasKey(e => e.Cpf)
                    .HasName("PRIMARY");

                entity.ToTable("comprador");

                entity.HasIndex(e => e.UsuarioLogin, "usuario_login_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("cpf");

                entity.Property(e => e.PrimeiroNome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("primeiro_nome");

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("sobrenome");

                entity.Property(e => e.UsuarioLogin)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("usuario_login");

                entity.HasOne(d => d.UsuarioLoginNavigation)
                    .WithOne(p => p.Comprador)
                    .HasForeignKey<Comprador>(d => d.UsuarioLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_comprador_usuario");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .HasColumnType("int unsigned")
                    .HasColumnName("cep");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(45)
                    .HasColumnName("complemento");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(19)
                    .HasColumnName("estado");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome");

                entity.Property(e => e.Numero)
                    .HasColumnType("int unsigned")
                    .HasColumnName("numero");

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("rua");
            });

            modelBuilder.Entity<FormasDePagamento>(entity =>
            {
                entity.ToTable("formas_de_pagamento");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Resposta).HasColumnName("resposta");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Numero)
                    .HasName("PRIMARY");

                entity.ToTable("item");

                entity.HasIndex(e => e.CompraId, "fk_item_compra_idx");

                entity.Property(e => e.Numero)
                    .HasColumnType("int unsigned")
                    .HasColumnName("numero");

                entity.Property(e => e.CompraId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("compra_id");

                entity.Property(e => e.Quantidade)
                    .HasColumnType("int unsigned")
                    .HasColumnName("quantidade");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(10,0)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.Compra)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_item_compra");
            });

            modelBuilder.Entity<Loja>(entity =>
            {
                entity.HasKey(e => e.Cnpj)
                    .HasName("PRIMARY");

                entity.ToTable("loja");

                entity.HasIndex(e => e.UsuarioLogin, "usuario_login_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("cnpj");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nome");

                entity.Property(e => e.NumeroDeVendas)
                    .HasColumnType("int unsigned")
                    .HasColumnName("numero_de_vendas");

                entity.Property(e => e.UsuarioLogin)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("usuario_login");

                entity.HasOne(d => d.UsuarioLoginNavigation)
                    .WithOne(p => p.Loja)
                    .HasForeignKey<Loja>(d => d.UsuarioLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_loja_usuario");
            });

            modelBuilder.Entity<Pagamento>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pagamento");

                entity.HasIndex(e => e.CompraId, "compra_id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CompraId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("compra_id");

                entity.Property(e => e.Parcelas)
                    .HasColumnType("int unsigned")
                    .HasColumnName("parcelas");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('aprovado','negado','esperando_confirmacao')")
                    .HasColumnName("status");

                entity.Property(e => e.Valor)
                    .HasColumnType("decimal(6,2)")
                    .HasColumnName("valor");

                entity.HasOne(d => d.Compra)
                    .WithOne()
                    .HasForeignKey<Pagamento>(d => d.CompraId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pagamento_compra");
            });

            modelBuilder.Entity<Pix>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pix");

                entity.Property(e => e.CopiaECola)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("copia_e_cola");

                entity.Property(e => e.QrCode)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("qr_code");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.ToTable("produto");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Especificacao)
                    .HasMaxLength(45)
                    .HasColumnName("especificacao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nome");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('venda','cadastro','cancelado')")
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Promocao>(entity =>
            {
                entity.HasKey(e => e.Numero)
                    .HasName("PRIMARY");

                entity.ToTable("promocao");

                entity.HasIndex(e => e.LojaCnpj, "fk_promocao_loja_idx");

                entity.Property(e => e.Numero)
                    .HasColumnType("int unsigned")
                    .HasColumnName("numero");

                entity.Property(e => e.DataFim).HasColumnName("data_fim");

                entity.Property(e => e.DataInicio).HasColumnName("data_inicio");

                entity.Property(e => e.LojaCnpj)
                    .HasColumnType("bigint unsigned")
                    .HasColumnName("loja_cnpj");

                entity.Property(e => e.Tipo)
                    .IsRequired()
                    .HasColumnType("enum('compra','item')")
                    .HasColumnName("tipo");

                entity.HasOne(d => d.LojaCnpjNavigation)
                    .WithMany(p => p.Promocaos)
                    .HasForeignKey(d => d.LojaCnpj)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_promocao_loja");
            });

            modelBuilder.Entity<SolicitaCadastro>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("solicita_cadastro");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(45)
                    .HasColumnName("observacao");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('cadastrado','em_analise','aprovado','negado')")
                    .HasColumnName("status");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<StatusItem>(entity =>
            {
                entity.ToTable("status_item");

                entity.Property(e => e.Id)
                    .HasColumnType("int unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("PRIMARY");

                entity.ToTable("usuario");

                entity.Property(e => e.Login)
                    .HasMaxLength(45)
                    .HasColumnName("login");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("senha");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('ativo','inativo','bloqueado','cancelado')")
                    .HasColumnName("status");
            });

            modelBuilder.Entity<UsuarioSistema>(entity =>
            {
                entity.HasKey(e => e.Login)
                    .HasName("PRIMARY");

                entity.ToTable("usuario_sistema");

                entity.Property(e => e.Login)
                    .HasMaxLength(45)
                    .HasColumnName("login");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nome");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("senha");
            });

            modelBuilder.Entity<UsuarioSistemaCategorium>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("usuario_sistema_categoria");

                entity.HasIndex(e => e.CategoriaId, "fk_usuario_sistema_categoria_id_idx");

                entity.HasIndex(e => e.UsuarioSistemaLogin, "fk_usuario_sistema_categoria_login_idx");

                entity.Property(e => e.CategoriaId)
                    .HasColumnType("int unsigned")
                    .HasColumnName("categoria_id");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Operacao)
                    .IsRequired()
                    .HasColumnType("enum('inserir','remover','atualizar')")
                    .HasColumnName("operacao");

                entity.Property(e => e.UsuarioSistemaLogin)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("usuario_sistema_login");

                entity.HasOne(d => d.Categoria)
                    .WithMany()
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_sistema_categoria_id");

                entity.HasOne(d => d.UsuarioSistemaLoginNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UsuarioSistemaLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_usuario_sistema_categoria_login");
            });

            modelBuilder.Entity<UsuarioUsuarioSistema>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("usuario_usuario_sistema");

                entity.HasIndex(e => e.UsuarioLogin, "usuario_login_idx");

                entity.HasIndex(e => e.UsuarioSistemaLogin, "usuario_sistema_login_idx");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.Operacao)
                    .IsRequired()
                    .HasColumnType("enum('inserir','remover','atualizar')")
                    .HasColumnName("operacao");

                entity.Property(e => e.UsuarioLogin)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("usuario_login");

                entity.Property(e => e.UsuarioSistemaLogin)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("usuario_sistema_login");

                entity.HasOne(d => d.UsuarioLoginNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UsuarioLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_login");

                entity.HasOne(d => d.UsuarioSistemaLoginNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UsuarioSistemaLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_sistema_login");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
