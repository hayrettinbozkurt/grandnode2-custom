namespace Grand.Domain.Orders
{
    public static class SystemOrderFieldNames
    {
        public static string ProductSize => "productSize";
        public static string SalesCampaignId => "salesCampaignId";
        public static string MerchantSku => "merchantSku";
        public static string MerchantId => "merchantId";
        public static string ProductName => "productName";
        public static string ProductOrigin => "productOrigin";
        public static string ProductCategoryId => "productCategoryId";

        public static string ProductColor => "productColor";
        public static string FastDeliveryOptions => "fastDeliveryOptions";
        public static string VatBaseAmount => "vatBaseAmount";
        public static string Barcode => "barcode";
        public static string LaborCost => "laborCost";

        public static string OrderLineItemStatusName => "orderLineItemStatusName";

        //OrderLine

        public static string LineItemPrice => "LineItemPrice";
        public static string LineItemDiscount => "LineItemDiscount";
        public static string LineItemTyDiscount => "LineItemTyDiscount";
     
                  
    }
}