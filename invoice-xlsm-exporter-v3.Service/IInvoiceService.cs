using invoice_xlsm_exporter_v3.Domain.Entities;
using invoice_xlsm_exporter_v3.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Service
{
    public interface IInvoiceService
    {
        Task<ResponseEntity> GetInvoices();
        Task<ResponseEntity> GetInvoiceByIdUser(int id);
        Task<ResponseEntity> GetInvoiceById(int id);

    }
}
