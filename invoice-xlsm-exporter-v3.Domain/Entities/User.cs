using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Domain.Entities
{
    public class User : BaseEntity
    {
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(10)]
        public string Role { get; set; }
        public DateTime CreatedDay { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
    }
}
