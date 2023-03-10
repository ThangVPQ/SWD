using System.Collections.Generic;
using System.Xml.Serialization;


namespace invoice_xlsm_exporter_v3.Service.Dto.Easyinvoice
{
	[XmlRoot(ElementName = "Product")]
	public class Product
	{

		[XmlElement(ElementName = "Code")]
		public object Code { get; set; }

		[XmlElement(ElementName = "ProdName")]
		public string ProdName { get; set; }

		[XmlElement(ElementName = "ProdPrice")]
		public double ProdPrice { get; set; }

		[XmlElement(ElementName = "ProdQuantity")]
		public int ProdQuantity { get; set; }

		[XmlElement(ElementName = "ProdType")]
		public int ProdType { get; set; }

		[XmlElement(ElementName = "ProdUnit")]
		public string ProdUnit { get; set; }

		[XmlElement(ElementName = "Pos")]
		public int Pos { get; set; }

		[XmlElement(ElementName = "Total")]
		public int Total { get; set; }

		[XmlElement(ElementName = "Amount")]
		public int Amount { get; set; }

		[XmlElement(ElementName = "IsDiscountRow")]
		public int IsDiscountRow { get; set; }
	}

	[XmlRoot(ElementName = "Products")]
	public class Products
	{

		[XmlElement(ElementName = "Product")]
		public List<Product> Product { get; set; }
	}

	[XmlRoot(ElementName = "Content")]
	public class Content
	{

		[XmlElement(ElementName = "Key")]
		public string Key { get; set; }

		[XmlElement(ElementName = "ArisingDate")]
		public string ArisingDate { get; set; }

		[XmlElement(ElementName = "ComFax")]
		public object ComFax { get; set; }

		[XmlElement(ElementName = "ComName")]
		public string ComName { get; set; }

		[XmlElement(ElementName = "ComTaxCode")]
		public int ComTaxCode { get; set; }

		[XmlElement(ElementName = "ComAddress")]
		public string ComAddress { get; set; }

		[XmlElement(ElementName = "ComPhone")]
		public object ComPhone { get; set; }

		[XmlElement(ElementName = "ComEmail")]
		public object ComEmail { get; set; }

		[XmlElement(ElementName = "ComBankNo")]
		public object ComBankNo { get; set; }

		[XmlElement(ElementName = "ComBankName")]
		public object ComBankName { get; set; }

		[XmlElement(ElementName = "Ikey")]
		public object Ikey { get; set; }

		[XmlElement(ElementName = "ParentName")]
		public object ParentName { get; set; }

		[XmlElement(ElementName = "InvoiceName")]
		public string InvoiceName { get; set; }

		[XmlElement(ElementName = "InvoicePattern")]
		public string InvoicePattern { get; set; }

		[XmlElement(ElementName = "SerialNo")]
		public string SerialNo { get; set; }

		[XmlElement(ElementName = "InvoiceNo")]
		public int InvoiceNo { get; set; }

		[XmlElement(ElementName = "PaymentMethod")]
		public string PaymentMethod { get; set; }

		[XmlElement(ElementName = "CusCode")]
		public object CusCode { get; set; }

		[XmlElement(ElementName = "CusName")]
		public string CusName { get; set; }

		[XmlElement(ElementName = "CusTaxCode")]
		public int CusTaxCode { get; set; }

		[XmlElement(ElementName = "CusPhone")]
		public object CusPhone { get; set; }

		[XmlElement(ElementName = "CusAddress")]
		public string CusAddress { get; set; }

		[XmlElement(ElementName = "CusBankName")]
		public object CusBankName { get; set; }

		[XmlElement(ElementName = "CusBankNo")]
		public object CusBankNo { get; set; }

		[XmlElement(ElementName = "Total")]
		public int Total { get; set; }

		[XmlElement(ElementName = "VATAmount")]
		public int VATAmount { get; set; }

		[XmlElement(ElementName = "Amount")]
		public int Amount { get; set; }

		[XmlElement(ElementName = "AmountInWords")]
		public string AmountInWords { get; set; }

		[XmlElement(ElementName = "Buyer")]
		public object Buyer { get; set; }

		[XmlElement(ElementName = "VATRate")]
		public int VATRate { get; set; }

		[XmlElement(ElementName = "Note")]
		public object Note { get; set; }

		[XmlElement(ElementName = "CusEmails")]
		public object CusEmails { get; set; }

		[XmlElement(ElementName = "amountInWordsL2")]
		public string AmountInWordsL2 { get; set; }

		[XmlElement(ElementName = "Products")]
		public Products Products { get; set; }

		[XmlElement(ElementName = "GrossValue")]
		public int GrossValue { get; set; }

		[XmlElement(ElementName = "GrossValue0")]
		public int GrossValue0 { get; set; }

		[XmlElement(ElementName = "VatAmount0")]
		public int VatAmount0 { get; set; }

		[XmlElement(ElementName = "GrossValue5")]
		public int GrossValue5 { get; set; }

		[XmlElement(ElementName = "VatAmount5")]
		public int VatAmount5 { get; set; }

		[XmlElement(ElementName = "GrossValue10")]
		public int GrossValue10 { get; set; }

		[XmlElement(ElementName = "VatAmount10")]
		public int VatAmount10 { get; set; }

		[XmlElement(ElementName = "GrossValueNDeclared")]
		public int GrossValueNDeclared { get; set; }

		[XmlElement(ElementName = "VatAmountNDeclared")]
		public int VatAmountNDeclared { get; set; }

		[XmlElement(ElementName = "GrossValueContractor")]
		public int GrossValueContractor { get; set; }

		[XmlElement(ElementName = "VatAmountContractor")]
		public int VatAmountContractor { get; set; }

		[XmlElement(ElementName = "ExchangeRate")]
		public int ExchangeRate { get; set; }

		[XmlElement(ElementName = "CurrencyUnit")]
		public string CurrencyUnit { get; set; }

		[XmlElement(ElementName = "PortalLink")]
		public string PortalLink { get; set; }

		[XmlElement(ElementName = "Hidden")]
		public string Hidden { get; set; }

		[XmlElement(ElementName = "SignDate")]
		public string SignDate { get; set; }

		[XmlAttribute(AttributeName = "Id")]
		public string Id { get; set; }

		[XmlText]
		public string Text { get; set; }
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
		public Transform Transform { get; set; }
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

		[XmlElement(ElementName = "X509Certificate")]
		public string X509Certificate { get; set; }
	}

	[XmlRoot(ElementName = "KeyInfo")]
	public class KeyInfo
	{

		[XmlElement(ElementName = "X509Data")]
		public X509Data X509Data { get; set; }
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

	[XmlRoot(ElementName = "Invoice")]
	public class Easyinvoice
	{

		[XmlElement(ElementName = "Content")]
		public Content Content { get; set; }

		[XmlElement(ElementName = "RowPerPage")]
		public int RowPerPage { get; set; }

		[XmlElement(ElementName = "qrCodeData")]
		public string QrCodeData { get; set; }

		[XmlElement(ElementName = "Signature")]
		public Signature Signature { get; set; }
	}


}
