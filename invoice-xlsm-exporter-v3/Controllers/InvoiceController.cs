﻿using Aspose.Cells;
using invoice_xlsm_exporter_v3.Service;
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
    public class InvoiceController : Controller
    {
        IUserService _userService;
        public InvoiceController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("importEnvoice")]
        public async Task<IActionResult> ImportInvoice([FromHeader] string userName, [FromForm] IFormFile file)
        {
            var result = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    result.AppendLine(reader.ReadLine());
                }
            }
            XmlDocument doc = new XmlDocument();
            var dataDir = @"F:\thang\";

            Workbook workbook = new Workbook();
            workbook.ImportXml(dataDir+ "ihoadon.vn_0102519041_269_05012023.xml", "Sheet1", 0, 0);
            workbook.Save(dataDir + "data_xml.xlsx", Aspose.Cells.SaveFormat.Auto);
            //doc.LoadXml(result.ToString());
            //var json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.None, true);
            return Ok(result.ToString());
        }
    }
}