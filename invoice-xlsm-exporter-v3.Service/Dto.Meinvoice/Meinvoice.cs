using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace invoice_xlsm_exporter_v3.Service.Dto.Meinvoice
{
	[XmlRoot(ElementName = "payment")]
	public class Payment
	{

		[XmlElement(ElementName = "paymentMethodName")]
		public string PaymentMethodName { get; set; }
	}

	[XmlRoot(ElementName = "payments")]
	public class Payments
	{

		[XmlElement(ElementName = "payment")]
		public Payment Payment { get; set; }
	}

	[XmlRoot(ElementName = "item")]
	public class Item
	{

		[XmlElement(ElementName = "lineNumber")]
		public int LineNumber { get; set; }

		[XmlElement(ElementName = "itemCode")]
		public string ItemCode { get; set; }

		[XmlElement(ElementName = "itemName")]
		public string ItemName { get; set; }

		[XmlElement(ElementName = "quantity")]
		public double Quantity { get; set; }

		[XmlElement(ElementName = "itemTotalAmountWithoutVat")]
		public int ItemTotalAmountWithoutVat { get; set; }

		[XmlElement(ElementName = "vatPercentage")]
		public int VatPercentage { get; set; }

		[XmlElement(ElementName = "vatAmount")]
		public int VatAmount { get; set; }

		[XmlElement(ElementName = "unitPrice")]
		public double UnitPrice { get; set; }

		[XmlElement(ElementName = "promotion")]
		public int Promotion { get; set; }
	}

	[XmlRoot(ElementName = "items")]
	public class Items
	{

		[XmlElement(ElementName = "item")]
		public Item Item { get; set; }
	}

	[XmlRoot(ElementName = "invoiceTaxBreakdown")]
	public class InvoiceTaxBreakdown
	{

		[XmlElement(ElementName = "vatPercentage")]
		public int VatPercentage { get; set; }
	}

	[XmlRoot(ElementName = "invoiceTaxBreakdowns")]
	public class InvoiceTaxBreakdowns
	{

		[XmlElement(ElementName = "invoiceTaxBreakdown")]
		public InvoiceTaxBreakdown InvoiceTaxBreakdown { get; set; }
	}

	[XmlRoot(ElementName = "invoiceData")]
	public class InvoiceData
	{

		[XmlElement(ElementName = "invoiceType")]
		public string InvoiceType { get; set; }

		[XmlElement(ElementName = "templateCode")]
		public string TemplateCode { get; set; }

		[XmlElement(ElementName = "invoiceSeries")]
		public string InvoiceSeries { get; set; }

		[XmlElement(ElementName = "invoiceNumber")]
		public int InvoiceNumber { get; set; }

		[XmlElement(ElementName = "invoiceName")]
		public string InvoiceName { get; set; }

		[XmlElement(ElementName = "invoiceIssuedDate")]
		public DateTime InvoiceIssuedDate { get; set; }

		[XmlElement(ElementName = "signedDate")]
		public DateTime SignedDate { get; set; }

		[XmlElement(ElementName = "currencyCode")]
		public string CurrencyCode { get; set; }

		[XmlElement(ElementName = "adjustmentType")]
		public int AdjustmentType { get; set; }

		[XmlElement(ElementName = "payments")]
		public Payments Payments { get; set; }

		[XmlElement(ElementName = "delivery")]
		public object Delivery { get; set; }

		[XmlElement(ElementName = "sellerLegalName")]
		public string SellerLegalName { get; set; }

		[XmlElement(ElementName = "sellerTaxCode")]
		public int SellerTaxCode { get; set; }

		[XmlElement(ElementName = "sellerAddressLine")]
		public string SellerAddressLine { get; set; }

		[XmlElement(ElementName = "sellerPhoneNumber")]
		public string SellerPhoneNumber { get; set; }

		[XmlElement(ElementName = "sellerFaxNumber")]
		public object SellerFaxNumber { get; set; }

		[XmlElement(ElementName = "sellerEmail")]
		public object SellerEmail { get; set; }

		[XmlElement(ElementName = "sellerWebSite")]
		public object SellerWebSite { get; set; }

		[XmlElement(ElementName = "sellerBankAccount")]
		public object SellerBankAccount { get; set; }

		[XmlElement(ElementName = "sellerBankName")]
		public object SellerBankName { get; set; }

		[XmlElement(ElementName = "buyerLegalName")]
		public string BuyerLegalName { get; set; }

		[XmlElement(ElementName = "buyerTaxCode")]
		public int BuyerTaxCode { get; set; }

		[XmlElement(ElementName = "buyerAddressLine")]
		public string BuyerAddressLine { get; set; }

		[XmlElement(ElementName = "deliveryOrderDate")]
		public DateTime DeliveryOrderDate { get; set; }

		[XmlElement(ElementName = "exchangeRate")]
		public double ExchangeRate { get; set; }

		[XmlElement(ElementName = "items")]
		public Items Items { get; set; }

		[XmlElement(ElementName = "invoiceTaxBreakdowns")]
		public InvoiceTaxBreakdowns InvoiceTaxBreakdowns { get; set; }

		[XmlElement(ElementName = "totalAmountWithoutVAT")]
		public int TotalAmountWithoutVAT { get; set; }

		[XmlElement(ElementName = "totalVATAmount")]
		public int TotalVATAmount { get; set; }

		[XmlElement(ElementName = "totalAmountWithVAT")]
		public int TotalAmountWithVAT { get; set; }

		[XmlElement(ElementName = "totalAmountWithVATInWords")]
		public string TotalAmountWithVATInWords { get; set; }

		[XmlElement(ElementName = "discountAmount")]
		public int DiscountAmount { get; set; }

		[XmlElement(ElementName = "isDiscountAmtPos")]
		public int IsDiscountAmtPos { get; set; }

		[XmlElement(ElementName = "totalAmountWithVATFrn")]
		public int TotalAmountWithVATFrn { get; set; }

		[XmlElement(ElementName = "userDefines")]
		public string UserDefines { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public string Id { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "controlData")]
	public class ControlData
	{

		[XmlElement(ElementName = "systemCode")]
		public string SystemCode { get; set; }
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

		[XmlAttribute(AttributeName = "XMLNS")]
		public string Xmlns { get; set; }

		[XmlAttribute(AttributeName = "Id")]
		public string Id { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "invoice")]
	public class Meinvoice
	{

		[XmlElement(ElementName = "invoiceData")]
		public InvoiceData InvoiceData { get; set; }

		[XmlElement(ElementName = "controlData")]
		public ControlData ControlData { get; set; }

		[XmlElement(ElementName = "Signature")]
		public Signature Signature { get; set; }

		[XmlAttribute(AttributeName = "inv")]
		public string Inv { get; set; }

		[XmlAttribute(AttributeName = "ds")]
		public string Ds { get; set; }

		[XmlText]
		public string Text { get; set; }
	}


}
