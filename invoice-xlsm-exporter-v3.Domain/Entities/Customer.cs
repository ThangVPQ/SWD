using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string CusName { get; set; }
        public string CusTaxCode { get; set; }
        public string CusAddress { get; set; }
        public string Status { get; set; }


    }
}
