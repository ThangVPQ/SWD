using Aspose.Cells;
using invoice_xlsm_exporter_v3.Service;
using invoice_xlsm_exporter_v3.Service.Dto.Easyinvoice;
using invoice_xlsm_exporter_v3.Service.Dto.Meinvoice;
using invoice_xlsm_exporter_v3.Service.Minvoice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace invoice_xlsm_exporter_v3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        IInvoiceService _invoiceService;
        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpPost]
        [Route("importEnvoice")]
        public async Task<IActionResult> ImportInvoice([FromHeader] string userName, [FromForm] IFormFile file)
        {
            return Ok(await _invoiceService.ExportFile(userName, file));
        }
        [Route("getInvoices")]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _invoiceService.GetInvoices());
        }

        [Route("getInvoicebyId={id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetInvoiceById(int id)
        {
            return Ok(await _invoiceService.GetInvoiceById(id));
        }
        [Route("getInvoicebyIdUser={id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetInvoiceByIdUser(int id)
        {
            return Ok(await _invoiceService.GetInvoiceByIdUser(id));
        }
    }
}
