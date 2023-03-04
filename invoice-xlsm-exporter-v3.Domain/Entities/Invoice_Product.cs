using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Domain.Entities
{
    public class Invoice_Product : BaseEntity
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public DateTime AddDate { get; set; }

        public string Status { get; set; }
    }
}
