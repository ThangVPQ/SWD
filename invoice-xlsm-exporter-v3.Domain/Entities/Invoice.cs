using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        [StringLength(50)]
        public string SerialNo { get; set; }

        public string InvoiceName { get; set; }
        public int InvoiceNo { get; set; }

        public string InvoicePattern { get; set; }

        public DateTime ArisingDate { get; set; }

        public string PaymentMethod { get; set; }

        public double Total { get; set; }

        public double VatAmount { get; set; }

        public int Amount { get; set; }
        public float VarRate { get; set; }
        public string CurrencyUnit { get; set; }
        public string status { get; set; }
        public DateTime ImportedDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }


    }
}
