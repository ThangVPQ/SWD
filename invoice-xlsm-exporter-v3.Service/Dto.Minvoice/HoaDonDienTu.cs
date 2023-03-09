using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace invoice_xlsm_exporter_v3.Service.Minvoice
{
	[XmlRoot(ElementName = "ThongTinHoaDon")]
	public class ThongTinHoaDon
	{

		[XmlElement(ElementName = "SellerAppRecordId")]
		public string SellerAppRecordId { get; set; }

		[XmlElement(ElementName = "TenHoaDon")]
		public string TenHoaDon { get; set; }

		[XmlElement(ElementName = "LoaiHoaDon")]
		public int LoaiHoaDon { get; set; }

		[XmlElement(ElementName = "MauSo")]
		public string MauSo { get; set; }

		[XmlElement(ElementName = "Kyhieu")]
		public string Kyhieu { get; set; }

		[XmlElement(ElementName = "SoHoaDon")]
		public int SoHoaDon { get; set; }

		[XmlElement(ElementName = "NgayHoaDon")]
		public DateTime NgayHoaDon { get; set; }

		[XmlElement(ElementName = "HinhThucThanhToan")]
		public string HinhThucThanhToan { get; set; }

		[XmlElement(ElementName = "MaTienTe")]
		public string MaTienTe { get; set; }

		[XmlElement(ElementName = "TyGia")]
		public double TyGia { get; set; }

		[XmlElement(ElementName = "TenNguoiBan")]
		public string TenNguoiBan { get; set; }

		[XmlElement(ElementName = "MaSoThueNguoiBan")]
		public int MaSoThueNguoiBan { get; set; }

		[XmlElement(ElementName = "DiaChiNguoiBan")]
		public string DiaChiNguoiBan { get; set; }

		[XmlElement(ElementName = "DienThoaiNguoiBan")]
		public object DienThoaiNguoiBan { get; set; }

		[XmlElement(ElementName = "TaiKhoanBenBan")]
		public object TaiKhoanBenBan { get; set; }

		[XmlElement(ElementName = "TenNguoiMua")]
		public object TenNguoiMua { get; set; }

		[XmlElement(ElementName = "TenDoanhNghiepMua")]
		public string TenDoanhNghiepMua { get; set; }

		[XmlElement(ElementName = "MaSoThueNguoiMua")]
		public string MaSoThueNguoiMua { get; set; }

		[XmlElement(ElementName = "DiaChiNguoiMua")]
		public string DiaChiNguoiMua { get; set; }

		[XmlElement(ElementName = "TaiKhoanBenMua")]
		public object TaiKhoanBenMua { get; set; }

		[XmlElement(ElementName = "SoDonHang")]
		public object SoDonHang { get; set; }

		[XmlElement(ElementName = "TongTienTruocThue")]
		public double TongTienTruocThue { get; set; }

		[XmlElement(ElementName = "TongTienChietKhau")]
		public double TongTienChietKhau { get; set; }

		[XmlElement(ElementName = "TongTienThue")]
		public double TongTienThue { get; set; }

		[XmlElement(ElementName = "TongTien")]
		public double TongTien { get; set; }

		[XmlElement(ElementName = "ThanhTienBangChu")]
		public string ThanhTienBangChu { get; set; }

		[XmlElement(ElementName = "NguoiDaiDienBan")]
		public string NguoiDaiDienBan { get; set; }

		[XmlElement(ElementName = "ChucVuBan")]
		public string ChucVuBan { get; set; }

		[XmlElement(ElementName = "PT_Thue")]
		public int PTThue { get; set; }

		[XmlElement(ElementName = "ma_dt")]
		public object MaDt { get; set; }

		[XmlElement(ElementName = "TongTienThue10")]
		public int TongTienThue10 { get; set; }

		[XmlElement(ElementName = "TongTienTruocThue10")]
		public int TongTienTruocThue10 { get; set; }

		[XmlElement(ElementName = "sobaomat")]
		public string Sobaomat { get; set; }

		[XmlElement(ElementName = "ten_nguoi_sd")]
		public object TenNguoiSd { get; set; }

		[XmlElement(ElementName = "phiBVMT")]
		public int PhiBVMT { get; set; }
	}

	[XmlRoot(ElementName = "ChiTiet")]
	public class ChiTiet
	{

		[XmlElement(ElementName = "stt")]
		public int Stt { get; set; }

		[XmlElement(ElementName = "MaHang")]
		public object MaHang { get; set; }

		[XmlElement(ElementName = "TenHang")]
		public string TenHang { get; set; }

		[XmlElement(ElementName = "SoLuong")]
		public double SoLuong { get; set; }

		[XmlElement(ElementName = "DonGia")]
		public double DonGia { get; set; }

		[XmlElement(ElementName = "TienTruocThue")]
		public int TienTruocThue { get; set; }

		[XmlElement(ElementName = "PhanTramChietKhau")]
		public double PhanTramChietKhau { get; set; }

		[XmlElement(ElementName = "TienChietKhau")]
		public double TienChietKhau { get; set; }

		[XmlElement(ElementName = "PhanTramThue")]
		public double PhanTramThue { get; set; }

		[XmlElement(ElementName = "TienThue")]
		public double TienThue { get; set; }

		[XmlElement(ElementName = "ThanhTien")]
		public int ThanhTien { get; set; }
	}

	[XmlRoot(ElementName = "ChiTietHoaDon")]
	public class ChiTietHoaDon
	{

		[XmlElement(ElementName = "ChiTiet")]
		public List<ChiTiet> ChiTiet { get; set; }
	}

	[XmlRoot(ElementName = "HoaDon")]
	public class HoaDon
	{

		[XmlElement(ElementName = "ThongTinHoaDon")]
		public ThongTinHoaDon ThongTinHoaDon { get; set; }

		[XmlElement(ElementName = "ChiTietHoaDon")]
		public ChiTietHoaDon ChiTietHoaDon { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "CertifiedData")]
	public class CertifiedData
	{

		[XmlElement(ElementName = "qrCodeData")]
		public string QrCodeData { get; set; }

		[XmlElement(ElementName = "ChuKySo")]
		public string ChuKySo { get; set; }

		[XmlElement(ElementName = "SoBaoMat")]
		public string SoBaoMat { get; set; }

		[XmlElement(ElementName = "NguoiKy")]
		public object NguoiKy { get; set; }

		[XmlElement(ElementName = "NgayKy")]
		public string NgayKy { get; set; }

		[XmlElement(ElementName = "DonViKy")]
		public string DonViKy { get; set; }

		[XmlElement(ElementName = "DonViPhanMem")]
		public string DonViPhanMem { get; set; }
	}

	[XmlRoot(ElementName = "CanonicalizationMethod")]
	public class CanonicalizationMethod
	{

		[XmlAttribute(AttributeName = "Algorithm")]
		public string Algorithm { get; set; }
	}

	[XmlRoot(ElementName = "SignatureMethod")]
	public class SignatureMethod
	{

		[XmlAttribute(AttributeName = "Algorithm")]
		public string Algorithm { get; set; }
	}

	[XmlRoot(ElementName = "Transform")]
	public class Transform
	{

		[XmlAttribute(AttributeName = "Algorithm")]
		public string Algorithm { get; set; }
	}

	[XmlRoot(ElementName = "Transforms")]
	public class Transforms
	{

		[XmlElement(ElementName = "Transform")]
		public List<Transform> Transform { get; set; }
	}

	[XmlRoot(ElementName = "DigestMethod")]
	public class DigestMethod
	{

		[XmlAttribute(AttributeName = "Algorithm")]
		public string Algorithm { get; set; }
	}

	[XmlRoot(ElementName = "Reference")]
	public class Reference
	{

		[XmlElement(ElementName = "Transforms")]
		public Transforms Transforms { get; set; }

		[XmlElement(ElementName = "DigestMethod")]
		public DigestMethod DigestMethod { get; set; }

		[XmlElement(ElementName = "DigestValue")]
		public string DigestValue { get; set; }

		[XmlAttribute(AttributeName = "URI")]
		public string URI { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "SignedInfo")]
	public class SignedInfo
	{

		[XmlElement(ElementName = "CanonicalizationMethod")]
		public CanonicalizationMethod CanonicalizationMethod { get; set; }

		[XmlElement(ElementName = "SignatureMethod")]
		public SignatureMethod SignatureMethod { get; set; }

		[XmlElement(ElementName = "Reference")]
		public Reference Reference { get; set; }
	}

	[XmlRoot(ElementName = "X509Data")]
	public class X509Data
	{

		[XmlElement(ElementName = "X509SubjectName")]
		public string X509SubjectName { get; set; }

		[XmlElement(ElementName = "X509Certificate")]
		public string X509Certificate { get; set; }
	}

	[XmlRoot(ElementName = "KeyInfo")]
	public class KeyInfo
	{

		[XmlElement(ElementName = "X509Data")]
		public X509Data X509Data { get; set; }

		[XmlElement(ElementName = "KeyValue")]
		public KeyValue KeyValue { get; set; }
	}

	[XmlRoot(ElementName = "Signature")]
	public class Signature
	{

		[XmlElement(ElementName = "SignedInfo")]
		public SignedInfo SignedInfo { get; set; }

		[XmlElement(ElementName = "SignatureValue")]
		public string SignatureValue { get; set; }

		[XmlElement(ElementName = "KeyInfo")]
		public KeyInfo KeyInfo { get; set; }
		[XmlAttribute(AttributeName = "Id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName = "XMLNS")]
		public string Xmlns { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "RSAKeyValue")]
	public class RSAKeyValue
	{

		[XmlElement(ElementName = "Modulus")]
		public string Modulus { get; set; }

		[XmlElement(ElementName = "Exponent")]
		public string Exponent { get; set; }
	}

	[XmlRoot(ElementName = "KeyValue")]
	public class KeyValue
	{

		[XmlElement(ElementName = "RSAKeyValue")]
		public RSAKeyValue RSAKeyValue { get; set; }
	}

	[XmlRoot(ElementName = "Signatures")]
	public class Signatures
	{

		[XmlElement(ElementName = "Signature")]
		public List<Signature> Signature { get; set; }
	}

	[XmlRoot(ElementName = "HoaDonDienTu")]
	public class HoaDonDienTu
	{

		[XmlElement(ElementName = "HoaDon")]
		public HoaDon HoaDon { get; set; }

		[XmlElement(ElementName = "CertifiedData")]
		public CertifiedData CertifiedData { get; set; }

		[XmlElement(ElementName = "Signatures")]
		public Signatures Signatures { get; set; }
	}


}
