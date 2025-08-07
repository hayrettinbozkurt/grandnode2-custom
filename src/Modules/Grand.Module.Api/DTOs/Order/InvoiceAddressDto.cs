namespace Grand.Module.Api.DTOs.Order
{
    public class InvoiceAddressDto : ShipmentAddressDto
    {
        public string TaxOffice { get; set; }
        public string TaxNumber { get; set; }
    }
}