namespace Grand.Module.Api.DTOs.Order
{
    public class DiscountDetailDto
    {
        public double LineItemPrice { get; set; }
        public double LineItemDiscount { get; set; }
        public double LineItemTyDiscount { get; set; }
    }
}