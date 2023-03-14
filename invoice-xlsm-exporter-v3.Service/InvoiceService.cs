using invoice_xlsm_exporter_v3.Data.Abstract;
using invoice_xlsm_exporter_v3.Domain.Entities;
using invoice_xlsm_exporter_v3.Dto;
using invoice_xlsm_exporter_v3.Service.Dto.Easyinvoice;
using invoice_xlsm_exporter_v3.Service.Dto.Meinvoice;
using invoice_xlsm_exporter_v3.Service.Minvoice;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using IronXL;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;

namespace invoice_xlsm_exporter_v3.Service
{
    public class InvoiceService : IInvoiceService
    {
        IRepository<Invoice> _invoiceRepository;
        IUserService _userService;
        public async Task<ResponseEntity> GetInvoices()
        {
            try
            {
                return new ResponseEntity(await _invoiceRepository.GetData(), true);

            }
            catch (Exception e)
            {
                return new ResponseEntity(null, false);
            }
        }
        public InvoiceService(IRepository<Invoice> invoiceRepository, IUserService userService)
        {
            _invoiceRepository = invoiceRepository;
            _userService = userService;
        }
        public async Task<ResponseEntity> GetInvoiceByIdUser(int id)
        {
            try
            {
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
            }
            catch (Exception e)
            {
                return new ResponseEntity(null, false);
            }

        }
        public async Task<ResponseEntity> GetInvoiceById(int id)
        {
            return new ResponseEntity(await _invoiceRepository.GetById(id), true);
        }

        public async Task<ResponseEntity> ExportFile(string userName, IFormFile file)
        {
            var result = new StringBuilder();
            Object resultingMessage;
            string Url = "";

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    result.AppendLine(reader.ReadLine());
                }
            }
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Easyinvoice));
                MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(result.Replace("xmlns", "XMLNS").ToString()));
                resultingMessage = (Easyinvoice)serializer.Deserialize(memStream);
                Url = ExportExcelEasyInvoice((Easyinvoice)resultingMessage);
                InsertEasyinvoice((Easyinvoice)resultingMessage, userName);
            }
            catch (Exception e)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(HoaDonDienTu));
                    MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(result.Replace("xmlns", "XMLNS").ToString()));
                    resultingMessage = (HoaDonDienTu)serializer.Deserialize(memStream);
                    Url = ExportExcelHoaDonDienTu((HoaDonDienTu)resultingMessage);
                    InsertMinvoice((HoaDonDienTu)resultingMessage, userName);
                }
                catch
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Meinvoice));
                    MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(result.Replace("XMLNS:inv", "inv").Replace("XMLNS:ds", "ds").Replace("inv:", "").ToString()));
                    resultingMessage = (Meinvoice)serializer.Deserialize(memStream);
                    Url = ExportExcelMeinvoice((Meinvoice)resultingMessage);
                    InsertMeinvoice((Meinvoice)resultingMessage, userName);

                }
            }
            return new ResponseEntity(Url, true);
        }
        private async void InsertEasyinvoice(Easyinvoice invoice, String username)
        {
            User user = (User)_userService.GetUserByName(username).Result.Data;
            if (user != null)
            {
                    Invoice _invoice = new Invoice();
                    _invoice.SerialNo = invoice.Content.SerialNo;
                    _invoice.InvoiceName = invoice.Content.InvoiceName;
                    _invoice.InvoiceNo = invoice.Content.InvoiceNo;
                    _invoice.InvoicePattern = invoice.Content.InvoicePattern;
                    _invoice.ArisingDate = DateTime.Parse(invoice.Content.ArisingDate);
                    _invoice.PaymentMethod = invoice.Content.PaymentMethod;
                    _invoice.Total = invoice.Content.Total;
                    _invoice.VatAmount = invoice.Content.VATAmount;
                    _invoice.Amount = invoice.Content.Amount;
                    _invoice.VarRate = invoice.Content.VATRate;
                    _invoice.CurrencyUnit = invoice.Content.CurrencyUnit;
                    _invoice.status = "active";
                    _invoice.UserId = user.Id;
                    _invoice.User = user;
                    _invoice.ImportedDate = DateTime.Now;
                    _invoiceRepository.Insert(_invoice);
                    _invoiceRepository.Commit();
            }

        }
        private async void InsertMinvoice(HoaDonDienTu invoice, String username)
        {
            User user = (User)_userService.GetUserByName(username).Result.Data;
            if (user != null)
            {
                    Invoice _invoice = new Invoice();
                    _invoice.SerialNo = invoice.HoaDon.ThongTinHoaDon.Kyhieu;
                    _invoice.InvoiceName = invoice.HoaDon.ThongTinHoaDon.TenHoaDon;
                    _invoice.InvoiceNo = invoice.HoaDon.ThongTinHoaDon.SoHoaDon;
                    _invoice.InvoicePattern = invoice.HoaDon.ThongTinHoaDon.MauSo;
                    _invoice.ArisingDate = invoice.HoaDon.ThongTinHoaDon.NgayHoaDon;
                    _invoice.PaymentMethod = invoice.HoaDon.ThongTinHoaDon.HinhThucThanhToan;
                    _invoice.Total = invoice.HoaDon.ThongTinHoaDon.TongTien;
                    _invoice.VatAmount = invoice.HoaDon.ThongTinHoaDon.TongTienThue;
                    _invoice.Amount = int.Parse(invoice.HoaDon.ThongTinHoaDon.TongTienTruocThue.ToString());
                    _invoice.VarRate = invoice.HoaDon.ThongTinHoaDon.PTThue;
                    _invoice.CurrencyUnit = invoice.HoaDon.ThongTinHoaDon.MaTienTe;
                    _invoice.status = "active";
                    _invoice.UserId = user.Id;
                    _invoice.User = user;
                    _invoice.ImportedDate = DateTime.Now;
                    _invoiceRepository.Insert(_invoice);
                    _invoiceRepository.Commit();
                
            }
                
        }
        private async void InsertMeinvoice(Meinvoice invoice, String username)
        {
            User user = (User)_userService.GetUserByName(username).Result.Data;
            if (user != null) {
                    Invoice _invoice = new Invoice();
                    _invoice.SerialNo = invoice.InvoiceData.InvoiceSeries;
                    _invoice.InvoiceName = invoice.InvoiceData.InvoiceName;
                    _invoice.InvoiceNo = invoice.InvoiceData.InvoiceNumber;
                    _invoice.InvoicePattern = invoice.InvoiceData.InvoiceType;
                    _invoice.ArisingDate = invoice.InvoiceData.InvoiceIssuedDate;
                    _invoice.PaymentMethod = invoice.InvoiceData.Payments.Payment.PaymentMethodName;
                    _invoice.Total = invoice.InvoiceData.TotalAmountWithVAT;
                    _invoice.VatAmount = invoice.InvoiceData.TotalVATAmount;
                    _invoice.Amount = invoice.InvoiceData.TotalAmountWithoutVAT;
                    _invoice.VarRate = invoice.InvoiceData.InvoiceTaxBreakdowns.InvoiceTaxBreakdown.VatPercentage;
                    _invoice.CurrencyUnit = "VND";
                    _invoice.status = "active";
                    _invoice.UserId = user.Id;
                    _invoice.ImportedDate = DateTime.Now;
                    _invoice.User = user;
                    _invoiceRepository.Insert(_invoice);
                    _invoiceRepository.Commit();
            }
        }
        private async Task<bool> CheckInvoiceAsync(String seriNo, int userid)
        {
            var data = await _invoiceRepository.GetData();
            foreach (var u in data)
            {
                if (u.SerialNo.Equals(seriNo) && u.UserId == userid) return false;
            }
            return true;
        }


        private string ExportExcelEasyInvoice(Easyinvoice invoice)
        {
            try
            {
                int row = 2;
                WorkBook workBook = WorkBook.Create(ExcelFileFormat.XLSX);
                workBook.Metadata.Author = "SWD";
                // Add a blank WorkSheet
                WorkSheet workSheet = workBook.CreateWorkSheet("main_sheet");
                // Add data and styles to the new worksheet
                workSheet["A1"].Value = "Mẫu Số HĐ";
                workSheet["B1"].Value = "Kí Hiệu HĐ";
                workSheet["C1"].Value = "Số HĐ";
                workSheet["D1"].Value = "Ngày HĐ";
                workSheet["E1"].Value = "Tên Khách Hàng";
                workSheet["F1"].Value = "Địa Chỉ";
                workSheet["G1"].Value = "Mã Số Thuế";
                workSheet["H1"].Value = "Tên Hàng";
                workSheet["I1"].Value = "Hình Thức Thanh Toán";
                workSheet["J1"].Value = "ĐVT";
                workSheet["K1"].Value = "Số Lượng";
                workSheet["L1"].Value = "Đơn Giá";
                workSheet["M1"].Value = "Thành Tiền";
                workSheet["N1"].Value = "% Thuế GTGT";
                workSheet["O1"].Value = "Tiền Thuế GTGT";
                workSheet["P1"].Value = "TK Thuế GTGT";
                foreach (var product in invoice.Content.Products.Product)
                {
                    workSheet["A" + row].Value = "EasyInvoice";
                    workSheet["B" + row].Value = invoice.Content.SerialNo;
                    workSheet["C" + row].Value = invoice.Content.Key;
                    workSheet["D" + row].Value = invoice.Content.ArisingDate;
                    workSheet["E" + row].Value = invoice.Content.CusName;
                    workSheet["F" + row].Value = invoice.Content.CusAddress;
                    workSheet["G" + row].Value = invoice.Content.CusTaxCode;
                    workSheet["H" + row].Value = product.ProdName;
                    workSheet["I" + row].Value = invoice.Content.PaymentMethod;
                    workSheet["J" + row].Value = product.ProdUnit;
                    workSheet["K" + row].Value = product.ProdQuantity;
                    workSheet["L" + row].Value = product.ProdPrice;
                    workSheet["M" + row].Value = product.Total;
                    workSheet["N" + row].Value = invoice.Content.VATRate;
                    workSheet["O" + row].Value = (product.Total * invoice.Content.VATRate / 100).ToString();
                    row++;
                }
                workBook.SaveAs(invoice.Content.Key + ".xlsx");
                return UploadFileToFireBase(invoice.Content.Key + ".xlsx").Result;
            }
            catch (Exception)
            {

            }
            return UploadFileToFireBase(invoice.Content.Key + ".xlsx").Result;
        }
        private string ExportExcelHoaDonDienTu(HoaDonDienTu invoice)
        {
            try
            {
                int row = 2;
                WorkBook workBook = WorkBook.Create(ExcelFileFormat.XLSX);
                workBook.Metadata.Author = "SWD";
                // Add a blank WorkSheet
                WorkSheet workSheet = workBook.CreateWorkSheet("main_sheet");
                // Add data and styles to the new worksheet
                workSheet["A1"].Value = "Mẫu Số HĐ";
                workSheet["B1"].Value = "Kí Hiệu HĐ";
                workSheet["C1"].Value = "Số HĐ";
                workSheet["D1"].Value = "Ngày HĐ";
                workSheet["E1"].Value = "Tên Khách Hàng";
                workSheet["F1"].Value = "Địa Chỉ";
                workSheet["G1"].Value = "Mã Số Thuế";
                workSheet["H1"].Value = "Tên Hàng";
                workSheet["I1"].Value = "Hình Thức Thanh Toán";
                workSheet["J1"].Value = "ĐVT";
                workSheet["K1"].Value = "Số Lượng";
                workSheet["L1"].Value = "Đơn Giá";
                workSheet["M1"].Value = "Thành Tiền";
                workSheet["N1"].Value = "% Thuế GTGT";
                workSheet["O1"].Value = "Tiền Thuế GTGT";
                workSheet["P1"].Value = "TK Thuế GTGT";
                foreach (var product in invoice.HoaDon.ChiTietHoaDon.ChiTiet)
                {
                    workSheet["A" + row].Value = "HoaDonDienTu";
                    workSheet["B" + row].Value = invoice.HoaDon.ThongTinHoaDon.MauSo;
                    workSheet["C" + row].Value = invoice.HoaDon.ThongTinHoaDon.SoHoaDon;
                    workSheet["D" + row].Value = invoice.HoaDon.ThongTinHoaDon.NgayHoaDon;
                    workSheet["E" + row].Value = invoice.HoaDon.ThongTinHoaDon.TenNguoiMua;
                    workSheet["F" + row].Value = invoice.HoaDon.ThongTinHoaDon.DiaChiNguoiMua;
                    workSheet["G" + row].Value = invoice.HoaDon.ThongTinHoaDon.MaSoThueNguoiMua;
                    workSheet["H" + row].Value = product.TenHang;
                    workSheet["I" + row].Value = invoice.HoaDon.ThongTinHoaDon.HinhThucThanhToan;
                    workSheet["K" + row].Value = product.SoLuong;
                    workSheet["L" + row].Value = product.DonGia;
                    workSheet["M" + row].Value = product.TienTruocThue;
                    workSheet["N" + row].Value = product.PhanTramThue;
                    workSheet["O" + row].Value = (product.TienTruocThue * product.PhanTramThue / 100).ToString();
                    workSheet["P" + row].Value = invoice.HoaDon.ThongTinHoaDon.MaSoThueNguoiBan;
                    row++;
                }
                workBook.SaveAs(invoice.HoaDon.ThongTinHoaDon.SellerAppRecordId + ".xlsx");
                return UploadFileToFireBase(invoice.HoaDon.ThongTinHoaDon.SellerAppRecordId + ".xlsx").Result;
            }
            catch (Exception)
            {

            }
            return UploadFileToFireBase(invoice.HoaDon.ThongTinHoaDon.SoHoaDon + ".xlsx").Result;
        }
        private string ExportExcelMeinvoice(Meinvoice invoice)
        {
            try
            {
                int row = 2;
                WorkBook workBook = WorkBook.Create(ExcelFileFormat.XLSX);
                workBook.Metadata.Author = "SWD";
                // Add a blank WorkSheet
                WorkSheet workSheet = workBook.CreateWorkSheet("main_sheet");
                // Add data and styles to the new worksheet
                workSheet["A1"].Value = "Mẫu Số HĐ";
                workSheet["B1"].Value = "Kí Hiệu HĐ";
                workSheet["C1"].Value = "Số HĐ";
                workSheet["D1"].Value = "Ngày HĐ";
                workSheet["E1"].Value = "Tên Khách Hàng";
                workSheet["F1"].Value = "Địa Chỉ";
                workSheet["G1"].Value = "Mã Số Thuế";
                workSheet["H1"].Value = "Tên Hàng";
                workSheet["I1"].Value = "Hình Thức Thanh Toán";
                workSheet["J1"].Value = "ĐVT";
                workSheet["K1"].Value = "Số Lượng";
                workSheet["L1"].Value = "Đơn Giá";
                workSheet["M1"].Value = "Thành Tiền";
                workSheet["N1"].Value = "% Thuế GTGT";
                workSheet["O1"].Value = "Tiền Thuế GTGT";
                workSheet["P1"].Value = "TK Thuế GTGT";
                foreach (var product in invoice.InvoiceData.Items.Item)
                {
                    workSheet["A" + row].Value = invoice.InvoiceData.TemplateCode;
                    workSheet["B" + row].Value = invoice.InvoiceData.InvoiceSeries;
                    workSheet["C" + row].Value = invoice.InvoiceData.InvoiceNumber;
                    workSheet["D" + row].Value = invoice.InvoiceData.InvoiceIssuedDate;
                    workSheet["E" + row].Value = invoice.InvoiceData.BuyerLegalName;
                    workSheet["F" + row].Value = invoice.InvoiceData.BuyerAddressLine;
                    workSheet["G" + row].Value = invoice.InvoiceData.BuyerTaxCode;
                    workSheet["H" + row].Value = product.ItemName;
                    workSheet["I" + row].Value = invoice.InvoiceData.Payments.Payment.PaymentMethodName;
                    workSheet["K" + row].Value = product.Quantity;
                    workSheet["L" + row].Value = product.UnitPrice;
                    workSheet["M" + row].Value = product.ItemTotalAmountWithoutVat;
                    workSheet["N" + row].Value = product.VatPercentage;
                    workSheet["O" + row].Value = product.VatAmount;
                    workSheet["P" + row].Value = invoice.InvoiceData.SellerTaxCode;
                    row++;
                }
                workBook.SaveAs(invoice.InvoiceData.InvoiceNumber + ".xlsx");
                return UploadFileToFireBase(invoice.InvoiceData.InvoiceNumber + ".xlsx").Result;
            }
            catch (Exception)
            {

            }
            return UploadFileToFireBase(invoice.InvoiceData.InvoiceSeries + ".xlsx").Result;
        }
        private async Task<string> UploadFileToFireBase(string fileName)
        {
            var objectName = fileName;
            var credential = GoogleCredential.FromFile("F:/Downloads/swdinvoice-2de04-firebase-adminsdk-ss018-b6b379aa13.json");
            string _bucketName = "swdinvoice-2de04.appspot.com";
            StorageClient _storageClient = StorageClient.Create(credential);
            using (var fileStream = File.Open(fileName, FileMode.Open))
            {
                var uploadObjectOptions = new UploadObjectOptions
                {
                };
                var result = await _storageClient.UploadObjectAsync(_bucketName, objectName, null, fileStream, uploadObjectOptions);
                string respone = result.MediaLink.Replace("/download/storage","").Replace("storage", "firebasestorage").Replace("v1","v0");
                return respone;
            }
        }
    }
}
