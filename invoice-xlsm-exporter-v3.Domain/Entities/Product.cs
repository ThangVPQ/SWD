using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string ProdName { get; set; }
        public double ProdPrice { get; set; }
        public int ProdType { get; set; }
        public string ProdUnit { get; set; }
        public int Pos { get; set; }
        public double Vat { get; set; }
        public string Status { get; set; }

        public ICollection<Invoice_Product> Invoice_Products { get; set; }

    }
}
