using Grand.Business.Core.Interfaces.Catalog.Products;
using Grand.Business.Core.Interfaces.Checkout.Orders;
using Grand.Business.Core.Interfaces.Checkout.Shipping;
using Grand.Business.Core.Interfaces.Common.Directory;
using Grand.Business.Core.Interfaces.Customers;
using Grand.Domain.Common;
using Grand.Domain.Customers;
using Grand.Domain.Orders;
using Grand.Domain.Shipping;
using Grand.Module.Api.Commands.Models.Order;
using Grand.Module.Api.DTOs.Order;
using MediatR;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization.Serializers;

namespace Grand.Module.Api.Commands.Handlers.Order
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
    {
        private readonly ICustomerService _customerService;
        private readonly IGroupService _groupService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        private readonly IShipmentService _shipmentService;

        private readonly ILogger<CreateOrderCommandHandler> _logger;
        public CreateOrderCommandHandler(ICustomerService customerService,
        IGroupService groupService,
        IProductService productService,
        IOrderService orderService,
        IShipmentService shipmentService,
         ILogger<CreateOrderCommandHandler> logger)
        {
            _customerService = customerService;
            _groupService = groupService;
            _productService = productService;
            _orderService = orderService;
            _shipmentService = shipmentService;
            _logger = logger;
        }
 

        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            string orderId = "";
            foreach (var item in request.Order.Content)
            {
                await CreateCustomer(request, "Guests");
                orderId = await PlaceOrder(item);
                await PrepareShipment(item, orderId);
            }

            return orderId;
        }

        private async Task CreateCustomer(CreateOrderCommand request, string groupName)
        {

            foreach (var item in request.Order.Content)
            {
                var customer = await _customerService.GetCustomerByEmail(item.CustomerEmail);
                if (customer is null)
                {
                    var group = await _groupService.GetCustomerGroupBySystemName(groupName);


                    await _customerService.InsertCustomer(new Customer {
                        Email = item.CustomerEmail,
                        Username = item.CustomerEmail,
                        UserFields = [new UserField{Key=SystemCustomerFieldNames.FirstName, Value=item.CustomerFirstName},
                                               new UserField{Key=SystemCustomerFieldNames.LastName, Value=item.CustomerLastName},
                                               new UserField{Key=SystemCustomerFieldNames.ImpersonatedCustomerId, Value=item.CustomerId.ToString()},
                                                new UserField{Key=SystemCustomerFieldNames.TcIdentityNumber, Value=item.TcIdentityNumber},
                                                 new UserField{Key=SystemCustomerFieldNames.IdentityNumber, Value=item.IdentityNumber}
                         ],
                        Groups = { group?.Id },
                        ShippingAddress = GetShippingAddress(item.ShipmentAddress),
                        BillingAddress = GetBillingAddress(item.InvoiceAddress)


                    });


                }
            }

        }

        private Address GetShippingAddress(ShipmentAddressDto dto)
        {
            return new Address {
                Id = dto.Id.ToString(),
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                City = dto.City,
                Company = dto.Company,
                ZipPostalCode = dto.PostalCode,
                CountryId = dto.CountyId.ToString(),
                PhoneNumber = dto.Phone,
                FirstName=dto.FirstName,
                LastName=dto.LastName,
                Attributes = [new CustomAttribute{ Key=SystemCustomerFieldNames.CityCode, Value=dto.CityCode.ToString()},
                new CustomAttribute{ Key=SystemCustomerFieldNames.District, Value=dto.District},
                new CustomAttribute{ Key=SystemCustomerFieldNames.DistrictId, Value=dto.DistrictId.ToString()},
                new CustomAttribute{ Key=SystemCustomerFieldNames.CountryName, Value=dto.CountyName},
                new CustomAttribute{ Key=SystemCustomerFieldNames.ShortAddress, Value=dto.ShortAddress},
                new CustomAttribute{ Key=SystemCustomerFieldNames.StateName, Value=dto.StateName},
                new CustomAttribute{ Key=SystemCustomerFieldNames.CountryCode, Value=dto.CountryCode},
                new CustomAttribute{ Key=SystemCustomerFieldNames.Neighborhood, Value=dto.Neighborhood},
                new CustomAttribute{ Key=SystemCustomerFieldNames.NeighborhoodId, Value=dto.NeighborhoodId.ToString()},
                new CustomAttribute{ Key=SystemCustomerFieldNames.FullName, Value=dto.FullName},
                new CustomAttribute{ Key=SystemCustomerFieldNames.FullAddress, Value=dto.FullAddress}]

            };
        }

        private Address GetBillingAddress(InvoiceAddressDto dto)
        {
            return new Address {
                Id = dto.Id.ToString(),
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                City = dto.City,
                Company = dto.Company,
                ZipPostalCode = dto.PostalCode,
                CountryId = dto.CountyId.ToString(),
                PhoneNumber = dto.Phone,
                Attributes = [
                new CustomAttribute{ Key=SystemCustomerFieldNames.District, Value=dto.District},
                new CustomAttribute{ Key=SystemCustomerFieldNames.DistrictId, Value=dto.DistrictId.ToString()},
                new CustomAttribute{ Key=SystemCustomerFieldNames.CountryName, Value=dto.CountyName},
                new CustomAttribute{ Key=SystemCustomerFieldNames.ShortAddress, Value=dto.ShortAddress},
                new CustomAttribute{ Key=SystemCustomerFieldNames.StateName, Value=dto.StateName},
                new CustomAttribute{ Key=SystemCustomerFieldNames.CountryCode, Value=dto.CountryCode},
                new CustomAttribute{ Key=SystemCustomerFieldNames.Neighborhood, Value=dto.Neighborhood},
                new CustomAttribute{ Key=SystemCustomerFieldNames.NeighborhoodId, Value=dto.NeighborhoodId.ToString()},
                new CustomAttribute{ Key=SystemCustomerFieldNames.FullName, Value=dto.FullName},
                new CustomAttribute{ Key=SystemCustomerFieldNames.FullAddress, Value=dto.FullAddress},
                new CustomAttribute{ Key=SystemCustomerFieldNames.TaxNumber, Value=dto.TaxNumber},
                new CustomAttribute{ Key=SystemCustomerFieldNames.TaxOffice, Value=dto.TaxOffice}
                ]

            };
        }

        private async Task<string> PlaceOrder(OrderContentDto dto)
        {
            Grand.Domain.Orders.Order order = new();

            Enum.TryParse(dto.Status, out ShippingStatus shipStatus);
            order.CustomerCurrencyCode = dto.CurrencyCode;
            order.OrderStatusId = (int)OrderItemStatus.ReturnAccepted;
            order.ShippingAddress = GetShippingAddress(dto.ShipmentAddress);
            order.BillingAddress = GetBillingAddress(dto.InvoiceAddress);
            order.CustomerEmail = dto.CustomerEmail;
            order.FirstName = dto.CustomerFirstName;
            order.LastName = dto.CustomerLastName;
            order.CustomerId = dto.CustomerId.ToString();
            order.OrderGuid = Guid.NewGuid();
            order.OrderTotal = dto.TotalPrice;
            order.OrderDiscount = dto.TotalDiscount;
            order.ShippingStatusId = shipStatus;
            order.ShippingMethod = dto.CargoProviderName;


            foreach (var item in dto.Lines)
            {
                var product = await _productService.GetProductBySku(item.Sku);
 
                if (product == null)
                {
                    _logger.LogError("product not found SKU: {0}",item.Sku);
                    
                    throw new Exception("product not found SKU:" + item.Sku);
                }
 
                 

                OrderItem orderItem = new OrderItem {
                    UnitPriceWithoutDiscExclTax = item.Amount,
                    UnitPriceWithoutDiscInclTax = item.Amount,
                    DiscountAmountExclTax = item.Discount,
                    DiscountAmountInclTax = item.Discount,
                    CustomData = prepareCustomData(item),
                    Attributes = prepareCustomAttributes(item),
                    Quantity = item.Quantity,
                    ProductId = item.ProductCode.ToString(),
                    Sku = item.Sku,
                    Id = item.Id.ToString()
                };

                order.OrderItems.Add(orderItem);

            }

            await _orderService.InsertOrder(order);

            return order.Id;
        }

        IList<Dictionary<string, object>> prepareDiscountData(List<DiscountDetailDto> discountDetails)
        {
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();

            foreach (var item in discountDetails)
            {
                lst.Add(new Dictionary<string, object>{{SystemOrderFieldNames.LineItemPrice,item.LineItemPrice},
                    { SystemOrderFieldNames.LineItemDiscount,item.LineItemDiscount},
                    {SystemOrderFieldNames.LineItemTyDiscount,item.LineItemTyDiscount}});
            }
            return lst;
        }

        IList<Dictionary<string, object>> prepareFastDeliveryData(List<FastDeliveryOptionDto> dto)
        {
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();

            foreach (var item in dto)
            {
                lst.Add(new Dictionary<string, object> { { SystemOrderFieldNames.FastDeliveryOptions, item.Type } });
            }
            return lst;
        }

        IList<Dictionary<string, object>> prepareCustomData(OrderLineDto dto)
        {
            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();


            lst.AddRange(prepareDiscountData(dto.DiscountDetails));
            lst.AddRange(prepareFastDeliveryData(dto.FastDeliveryOptions));

            return lst;
        }



        private IList<CustomAttribute> prepareCustomAttributes(OrderLineDto dto)
        {
            List<CustomAttribute> attributes = new();
            attributes.Add(new CustomAttribute { Key = SystemOrderFieldNames.SalesCampaignId, Value = dto.SalesCampaignId.ToString() });
            attributes.Add(new CustomAttribute { Key = SystemOrderFieldNames.ProductSize, Value = dto.ProductSize });
            attributes.Add(new CustomAttribute { Key = SystemOrderFieldNames.MerchantSku, Value = dto.MerchantSku });
            attributes.Add(new CustomAttribute { Key = SystemOrderFieldNames.MerchantId, Value = dto.MerchantId.ToString() });
            attributes.Add(new CustomAttribute { Key = SystemOrderFieldNames.ProductOrigin, Value = dto.ProductOrigin });
            attributes.Add(new CustomAttribute { Key = SystemOrderFieldNames.VatBaseAmount, Value = dto.VatBaseAmount.ToString() });
            attributes.Add(new CustomAttribute { Key = SystemOrderFieldNames.LaborCost, Value = dto.LaborCost.ToString() });
            attributes.Add(new CustomAttribute { Key = SystemOrderFieldNames.Barcode, Value = dto.Barcode });
            attributes.Add(new CustomAttribute { Key = SystemOrderFieldNames.ProductColor, Value = dto.ProductColor });
            attributes.Add(new CustomAttribute { Key = SystemOrderFieldNames.OrderLineItemStatusName, Value = dto.OrderLineItemStatusName });

            return attributes;
        }

        async Task PrepareShipment(OrderContentDto dto, string orderId)
        {
            Shipment shipment = new Shipment();
            ShipmentItem shipmentItem = new ShipmentItem();

            shipment.OrderId = orderId;
            shipmentItem.Attributes.Add(new CustomAttribute { Key = "cargoProviderName", Value = dto.CargoProviderName });
            shipmentItem.Attributes.Add(new CustomAttribute { Key = "cargoSenderNumber", Value = dto.CargoSenderNumber });
            shipmentItem.Attributes.Add(new CustomAttribute { Key = "cargoTrackingLink", Value = dto.CargoTrackingLink });
            shipmentItem.Attributes.Add(new CustomAttribute { Key = "cargoTrackingNumber", Value = dto.CargoTrackingNumber.ToString() });
            shipmentItem.Attributes.Add(new CustomAttribute { Key = "agreedDeliveryDate", Value = ConvertUnixToDateTime(dto.AgreedDeliveryDate).ToString() });
            shipmentItem.Attributes.Add(new CustomAttribute { Key = "agreedDeliveryDateExtendible", Value = dto.AgreedDeliveryDateExtendible.ToString() });
            shipmentItem.Attributes.Add(new CustomAttribute { Key = "extendedAgreedDeliveryDate", Value = ConvertUnixToDateTime(dto.ExtendedAgreedDeliveryDate).ToString() });
            shipmentItem.Attributes.Add(new CustomAttribute { Key = "agreedDeliveryDate", Value = ConvertUnixToDateTime(dto.AgreedDeliveryDate).ToString() });
            shipmentItem.Attributes.Add(new CustomAttribute { Key = "originShipmentDate", Value = ConvertUnixToDateTime(dto.OriginShipmentDate).ToString() });


            shipment.ShipmentItems.Add(shipmentItem);

            await _shipmentService.InsertShipment(shipment);
        }

        DateTime ConvertUnixToDateTime(long time)
        {
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(time);
            DateTime dateTime = dateTimeOffset.UtcDateTime;
            return dateTime;
        }
    }
}