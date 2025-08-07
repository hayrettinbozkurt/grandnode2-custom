namespace Grand.Module.Api.DTOs.Order
{
    public class OrderContentDto
    {
         public ShipmentAddressDto ShipmentAddress { get; set; }
    public string OrderNumber { get; set; }
    public double GrossAmount { get; set; }
    public double TotalDiscount { get; set; }
    public double TotalTyDiscount { get; set; }
    public string TaxNumber { get; set; }
    public InvoiceAddressDto InvoiceAddress { get; set; }
    public string CustomerFirstName { get; set; }
    public string CustomerEmail { get; set; }
    public long CustomerId { get; set; }
    public string CustomerLastName { get; set; }
    public long Id { get; set; } // shipmentPackageId
    public long CargoTrackingNumber { get; set; }
    public string CargoTrackingLink { get; set; }
    public string CargoSenderNumber { get; set; }
    public string CargoProviderName { get; set; }
    public List<OrderLineDto> Lines { get; set; }
    public long OrderDate { get; set; }
    public string TcIdentityNumber { get; set; }
    public string IdentityNumber { get; set; }
    public string CurrencyCode { get; set; }
    public List<PackageHistoryDto> PackageHistories { get; set; }
    public string ShipmentPackageStatus { get; set; }
    public string Status { get; set; }
    public string DeliveryType { get; set; }
    public int TimeSlotId { get; set; }
    public string ScheduledDeliveryStoreId { get; set; }
    public long EstimatedDeliveryStartDate { get; set; }
    public long EstimatedDeliveryEndDate { get; set; }
    public double TotalPrice { get; set; }
    public string DeliveryAddressType { get; set; }
    public long AgreedDeliveryDate { get; set; }
    public bool AgreedDeliveryDateExtendible { get; set; }
    public long ExtendedAgreedDeliveryDate { get; set; }
    public long AgreedDeliveryExtensionStartDate { get; set; }
    public long AgreedDeliveryExtensionEndDate { get; set; }
    public string InvoiceLink { get; set; }
    public bool FastDelivery { get; set; }
    public string FastDeliveryType { get; set; }
    public long OriginShipmentDate { get; set; }
    public long LastModifiedDate { get; set; }
    public bool Commercial { get; set; }
    public bool DeliveredByService { get; set; }
    public bool Micro { get; set; }
    public bool GiftBoxRequested { get; set; }
    public string EtgbNo { get; set; }
    public long EtgbDate { get; set; }
    public bool _3pByTrendyol { get; set; }
    public bool ContainsDangerousProduct { get; set; }
    }
}