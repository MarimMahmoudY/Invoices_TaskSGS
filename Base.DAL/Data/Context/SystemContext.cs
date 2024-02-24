using System;
using System.Collections.Generic;
using Base.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Base.DAL;
public class SystemContext : DbContext
{
    public DbSet<InvoiceHDR> Invoices { get; set; }
    public DbSet<ItemDTL> Items { get; set; }
    public SystemContext(DbContextOptions<SystemContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var invoices1 = new List<InvoiceHDR>
            {
                new InvoiceHDR
                {
                    InvoiceID= 1,
                    InvoiceDate= DateTime.Now,
                    PaymentMethod=true,
                    Customer="Ali",
                    Description="description field"
                },
                new InvoiceHDR
                {
                    InvoiceID= 2,
                    InvoiceDate= DateTime.Now,
                    PaymentMethod=false,
                    Customer="Ahmed",
                    Description="description field##"
                },
                new InvoiceHDR
                {
                    InvoiceID= 3,
                    InvoiceDate= DateTime.Now,
                    PaymentMethod=true,
                    Customer="Nour",
                    Description="description field"
                }
            };
        var items1 = new List<ItemDTL>
        {
            new ItemDTL
            {
                ItemId= 1,
                InvoiceHDRId= 1,
                ItemName="bread",
                Qty= 20,
                Price= 10,
            },
            new ItemDTL
            {
                ItemId= 9,
                InvoiceHDRId= 2,
                ItemName="cup",
                Qty= 20,
                Price= 10,
            },
            new ItemDTL
            {
                ItemId= 2,
                InvoiceHDRId= 3,
                ItemName="tea",
                Qty= 20,
                Price= 20,
            },
            new ItemDTL
            {
                ItemId= 3,
                InvoiceHDRId= 1,
                ItemName="milk",
                Qty= 10,
                Price= 10,
            },
        };


        modelBuilder.Entity<InvoiceHDR>().HasData(invoices1);
        modelBuilder.Entity<ItemDTL>().HasData(items1);


    }
}
