namespace Grand.Module.Api.DTOs.Order
{
    public class OrderLineDto
    {
        public int Quantity { get; set; }
    public long SalesCampaignId { get; set; }
    public string ProductSize { get; set; }
    public string MerchantSku { get; set; }
    public string ProductName { get; set; }
    public long ProductCode { get; set; }
    public string ProductOrigin { get; set; }
    public long MerchantId { get; set; }
    public double Amount { get; set; }
    public double Discount { get; set; }
    public double TyDiscount { get; set; }
    public List<DiscountDetailDto> DiscountDetails { get; set; }
    public List<FastDeliveryOptionDto> FastDeliveryOptions { get; set; }
    public string CurrencyCode { get; set; }
    public string ProductColor { get; set; }
    public long Id { get; set; } // orderLineId
    public string Sku { get; set; }
    public double VatBaseAmount { get; set; }
    public string Barcode { get; set; }
    public string OrderLineItemStatusName { get; set; }
    public double Price { get; set; }
    public int ProductCategoryId { get; set; }
    public double LaborCost { get; set; }
    }
}