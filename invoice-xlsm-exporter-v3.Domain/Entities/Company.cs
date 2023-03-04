using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string ComName { get; set; }
        public string ComTaxCode { get; set; }
        public string ComAddress { get; set; }
        public string Status { get; set; }
    }
}
