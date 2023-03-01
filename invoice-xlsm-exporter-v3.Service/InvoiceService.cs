using invoice_xlsm_exporter_v3.Data.Abstract;
using invoice_xlsm_exporter_v3.Domain.Entities;
using invoice_xlsm_exporter_v3.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace invoice_xlsm_exporter_v3.Service
{
    public class InvoiceService : IInvoiceService
    {
        IRepository<Invoice> _invoiceRepository;
        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            try
            {
                return await _invoiceRepository.GetData();
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public InvoiceService(IRepository<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<IEnumerable<Invoice>> GetInvoiceByIdUser(int id)
        {
            List<Invoice> list =  new List<Invoice>();
            var data = await _invoiceRepository.GetData();
            foreach (var invoice in data)
            {
                if (invoice.UserId.Equals(id))
                {
                    list.Add(invoice);
                }
            }
            return list;
        }
        public async Task<ResponseEntity> GetInvoiceById(int id)
        {
            return new ResponseEntity(_invoiceRepository.GetById(id), false);
        }

    }
}
