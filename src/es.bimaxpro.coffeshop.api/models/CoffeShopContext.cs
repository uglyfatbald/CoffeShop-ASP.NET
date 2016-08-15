using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace es.bimaxpro.coffeshop.api.models
{
    public class CoffeShopContext : DbContext
    {
        public CoffeShopContext(DbContextOptions<CoffeShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoEntity>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.Property(e => e.nombre).IsRequired();
                entity.Property(e => e.bebida).IsRequired();
            });

        }

        public virtual DbSet<PedidoEntity> Pedido { get; set; }
    }
}
