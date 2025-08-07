namespace Grand.Module.Api.DTOs.Order
{
    public class OrderDto
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalPages { get; set; }
        public int TotalElements { get; set; }
        public List<OrderContentDto> Content { get; set; }
    }
}