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
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
