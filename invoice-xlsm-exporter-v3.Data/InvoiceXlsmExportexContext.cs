using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using invoice_xlsm_exporter_v3.Domain.Entities;

namespace invoice_xlsm_exporter_v3.Data
{
    public class InvoiceXlsmExportexContext : DbContext
    {
        public InvoiceXlsmExportexContext(DbContextOptions<InvoiceXlsmExportexContext> options) : base(options)
        {

        }

        //small diff Users to User
        public DbSet<User> Users { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice_Product> Invoice_Products { get; set; }
        
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Invoice_Product>()
            .HasKey(e => new { e.InvoiceId, e.ProductId });

            modelBuilder.Entity<Invoice_Product>()
                .HasOne(e => e.Invoice)
                .WithMany(s => s.Invoice_Products)
                .HasForeignKey(e => e.InvoiceId);

            modelBuilder.Entity<Invoice_Product>()
                .HasOne(e => e.Product)
                .WithMany(c => c.Invoice_Products)
                .HasForeignKey(e => e.ProductId);

            modelBuilder.Entity<Invoice_Product>()
                .Property(e => e.Quantity)
                .IsRequired();

            modelBuilder.Entity<Invoice_Product>()
                .Property(e => e.AddDate)
                .IsRequired();

            modelBuilder.Entity<Invoice_Product>()
                .Property(e => e.Status)
                .IsRequired();

        }
    }
}
