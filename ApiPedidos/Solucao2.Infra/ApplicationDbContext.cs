using ApiPedidos.Domain;
using Microsoft.EntityFrameworkCore;
using Solucao2.Domain;
using Solucao2.Domain.ValueObjects;
using System;

public class ApplicationDbContext : DbContext
{
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoEvents> EventosPedidos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PedidosDb;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pedido>().ToTable("Pedidos");

        modelBuilder.Ignore<PedidoStatus>();

        modelBuilder.Entity<Pedido>()
           .Property(p => p.Status)
           .HasConversion(
               status => status.Valor, 
               valor => new PedidoStatus(valor)
            );

        modelBuilder.Entity<PedidoEvents>()
            .HasOne(pe => pe.Pedido)
            .WithMany()
            .HasForeignKey(pe => pe.PedidoId);

        modelBuilder.Entity<PedidoEvents>()
            .Property(e => e.Status)
            .HasConversion(
                status => status.Valor,
                valor => new PedidoStatus(valor)
            );
    }
}
