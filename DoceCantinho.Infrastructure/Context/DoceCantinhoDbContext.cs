
using DoceCantinho.Domain.Entities;
using DoceCantinho.Domain.Interfaces;

using DoceCantinho.Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using DoceCantinho.Infrastructure.Identity;

namespace DoceCantinho.Infrastructure.Context
{
    public class DoceCantinhoDbContext : IdentityDbContext<ApplicationUser>
    {
        public DoceCantinhoDbContext(DbContextOptions<DoceCantinhoDbContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// DbSet que representa a tabela de Doces no banco de dados.
        /// </summary>
        public DbSet<Doce> Doces { get; set; }
        public DbSet<DoceCantinho.Domain.Entities.Pedido> Pedidos { get; set; }
        public DbSet<DoceCantinho.Domain.Entities.PedidoItem> PedidoItems { get; set; }

        /// <summary>
        /// Persistência simples de carrinho por usuário (JSON).
        /// </summary>
        public DbSet<DoceCantinho.Domain.Entities.CartPersistence> CartPersistences { get; set; }

        /// <summary>
        /// DbSet que representa a tabela de Categories no banco de dados.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DoceConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            // Pedidos
            modelBuilder.Entity<DoceCantinho.Domain.Entities.Pedido>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.NomeCliente).IsRequired().HasMaxLength(200);
                b.Property(p => p.UserId).IsRequired().HasMaxLength(450); // FK para IdentityUser
                b.Property(p => p.Total).HasPrecision(18, 2);
                b.Property(p => p.Status).HasMaxLength(50);
                b.HasMany(p => p.Items).WithOne(i => i.Pedido).HasForeignKey(i => i.PedidoId);
            });

            modelBuilder.Entity<DoceCantinho.Domain.Entities.PedidoItem>(b =>
            {
                b.HasKey(i => i.Id);
                b.Property(i => i.Nome).IsRequired().HasMaxLength(200);
                b.Property(i => i.Preco).HasPrecision(18, 2);
            });
        }

    }
}
