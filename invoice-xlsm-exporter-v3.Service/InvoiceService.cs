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
        public async Task<ResponseEntity> GetInvoices()
        {
            try
            {
                return new ResponseEntity(await _invoiceRepository.GetData(), true);

            }
            catch(Exception e)
            {
                return new ResponseEntity(null, false);
            }
        }
        public InvoiceService(IRepository<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public async Task<ResponseEntity> GetInvoiceByIdUser(int id)
        {
            try {
                List<Invoice> list = new List<Invoice>();
                var data = await _invoiceRepository.GetData();
                foreach (var invoice in data)
                {
                    if (invoice.UserId.Equals(id))
                    {
                        list.Add(invoice);
                    }
                }
                return new ResponseEntity(list, true);
            }catch(Exception e)
            {
                return new ResponseEntity(null, false);
            }
           
        }
        public async Task<ResponseEntity> GetInvoiceById(int id)
        {
            return new ResponseEntity(await _invoiceRepository.GetById(id), true);
        }

    }
}
