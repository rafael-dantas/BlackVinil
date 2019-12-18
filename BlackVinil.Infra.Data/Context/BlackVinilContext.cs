using BlackVinil.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackVinil.Infra.Data.Context
{
    public class BlackVinilContext : DbContext
    {
        public BlackVinilContext(DbContextOptions option) : base(option) {}
        public BlackVinilContext() { }


        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Disco> Disco { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryProvider");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().HasAlternateKey(p => p.Id);
            modelBuilder.Entity<PedidoItem>().HasAlternateKey(i => i.Id);
            //modelBuilder.Entity<Disco>().HasAlternateKey(d => d.Id);
        }
    }
}
