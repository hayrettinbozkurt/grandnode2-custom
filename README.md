# Order Creation API

This API provides functionality to create orders in the GrandNode system via a POST request.

## Endpoint

```
POST /api/order
```

### Content-Type
```
application/json
```

---

## Request Body

```json
{
    "page": 0,
    "size": 50,
    "totalPages": 1,
    "totalElements": 1,
    "content": [
        {
            "shipmentAddress": {
                "id": 80844024,
                "firstName": "Trendyol",
                "lastName": "Müşterisi",
                "company": "",
                "address1": "DSM Grup Danışmanlık İletişim ve Satış Tic. A.Ş. Büyükdere Caddesi Noramin İş Merkezi No:237 Kat:B1 ",
                "address2": "",
                "addressLines": {
                    "addressLine1": "xxx",
                    "addressLine2": "xxx"
                },
                "city": " İstanbul ",
                "cityCode": 34,
                "district": "Şişli",
                "districtId": 54,
                "countyId": 0, // CEE bölgesi için gelecektir.
                "countyName": "XXX", // CEE bölgesi için gelecektir.
                "shortAddress": "xxx", // GULF bölgesi için gelecektir.
                "stateName": "xxx", // GULF bölgesi için gelecektir.
                "postalCode": "10D",        
                "countryCode": "TR",
                "neighborhoodId": 32126,
                "neighborhood": "Beyazıt Mah",
                "phone": null,
                "fullName": "Trendyol Müşterisi",
                "fullAddress": "DSM Grup Danışmanlık İletişim ve Satış Tic. A.Ş. Büyükdere Caddesi Noramin İş Merkezi No:237 Kat:B1   Şişli  İstanbul "
            },
            "orderNumber": "80869231",
            "grossAmount": 51.98,
            "totalDiscount": 25.99,
            "totalTyDiscount": 0.00, // commercial true olduğu durumda dolu gelebilir, false olduğu durumda 0 dönecektir.
            "taxNumber": null,
            "invoiceAddress": {
                "id": 80844023,
                "firstName": "Trendyol",
                "lastName": "Müşterisi",
                "company": "", // GULF bölgesi siparişlerinde boş gelebilir.
                "address1": "DSM Grup Danışmanlık İletişim ve Satış Tic. A.Ş. Büyükdere Caddesi Noramin İş Merkezi No:237 Kat:B1 ",
                "address2": "", // GULF bölgesi siparişlerinde boş gelebilir.
                "addressLines": {
                    "addressLine1": "xxx",
                    "addressLine2": "xxx"
                },
                "city": " İstanbul ",
                "district": "Şişli", // GULF bölgesi siparişlerinde boş gelebilir.
                "districtId": 1234,
                "countyId": 0, // CEE bölgesi için gelecektir.
                "countyName": "XXX", // CEE bölgesi için gelecektir.
                "shortAddress": "xxx", // GULF bölgesi için gelecektir.
                "stateName": "xxx", // GULF bölgesi için gelecektir.
                "postalCode": "", // GULF bölgesi siparişlerinde boş gelebilir.
                "countryCode": "TR",
                "neighborhoodId": 32126,
                "neighborhood": "Beyazıt Mah",
                "phone": null,
                "fullName": "Trendyol Müşterisi",
                "fullAddress": "DSM Grup Danışmanlık İletişim ve Satış Tic. A.Ş. Büyükdere Caddesi Noramin İş Merkezi No:237 Kat:B1   Şişli  İstanbul",
                "taxOffice": "Company of OMS's Tax Office", // Kurumsal fatura olmadığı durumda (commercial=false ise) body içerisinde dönmeyecektir.
                "taxNumber": "Company of OMS's Tax Number" // Kurumsal fatura olmadığı durumda (commercial=false ise)) body içerisinde dönmeyecektir.
            },
            "customerFirstName": "Trendyol",
            "customerEmail": "pf+dym24k@trendyolmail.com",
            "customerId": 99993706,
            "customerLastName": "Müşterisi",
            "id": 11650604, //shipmentPackageId
            "cargoTrackingNumber": 7340447182689,
            "cargoTrackingLink": "https://kargotakip.trendyol.com/?token=",
            "cargoSenderNumber": "733861966410",
            "cargoProviderName": "Trendyol Express Marketplace",
            "lines": [
                {
                    "quantity": 2,
                    "salesCampaignId": 201642,
                    "productSize": " one size",
                    "merchantSku": "merchantSku",
                    "productName": "Kadın Çivit Mavi Geometrik Desenli Kapaklı Clutch sku1234 sku1234, one size",
                    "productCode": 11954798,
                    "productOrigin": "Tr",
                    "merchantId": 201,
                    "amount": 25.99,
                    "discount": 13.00,
                    "tyDiscount": 0.00, // commercial true olduğu durumda dolu gelebilir, false olduğu durumda 0 dönecektir.
                    "discountDetails": [
                        {
                            "lineItemPrice": 13.00,
                            "lineItemDiscount": 12.99,
                            "lineItemTyDiscount": 0.00 // commercial true olduğu durumda dolu gelebilir, false olduğu durumda 0 dönecektir.
                        },
                        {
                            "lineItemPrice": 12.99,
                            "lineItemDiscount": 13.00,
                            "lineItemTyDiscount": 0.00 // commercial true olduğu durumda dolu gelebilir, false olduğu durumda 0 dönecektir.
                        }
                    ],
                    "fastDeliveryOptions": [
                        {
                            "type": "SameDayShipping"
                        },
                        {
                            "type": "FastDelivery"
                        }
                    ],
                    "currencyCode": "TRY",
                    "productColor": "No Color",
                    "id": 56040534, // orderLineId
                    "sku": "sku1234",
                    "vatBaseAmount": 8,
                    "barcode": "barcode1234",
                    "orderLineItemStatusName": "ReturnAccepted",
                    "price": 12.99,
                    "productCategoryId": 11111,
                    "laborCost": 11.11
                }
            ],
            "orderDate": 1542801149863,
            "tcIdentityNumber": "99999999999",
            "identityNumber": "0000000000000",
            "currencyCode": "TRY",
            "packageHistories": [
                {
                    "createdDate": 1542790350607,
                    "status": "Created"
                },
                {
                    "createdDate": 1543789070462,
                    "status": "Delivered"
                },
                {
                    "createdDate": 1542872460911,
                    "status": "Picking"
                },
                {
                    "createdDate": 1542953901874,
                    "status": "Shipped"
                }
            ],
            "shipmentPackageStatus": "ReturnAccepted",
            "status": "Shipped",
            "deliveryType": "normal", // her zaman "normal" olarak dönecektir
            "timeSlotId": 0,
            "scheduledDeliveryStoreId": "",
            "estimatedDeliveryStartDate": 1614605119000,
            "estimatedDeliveryEndDate": 1615296319000,
            "totalPrice": 469.90,
            "deliveryAddressType": "Shipment",
            "agreedDeliveryDate": 1622549842955, // Ürüne belirtilmiş termin süresinden hesaplanan siparişin gecikmeden kargoya verilmesi için son gündür.
            "agreedDeliveryDateExtendible": true, // true/fale satıcı ek süre girebilir mi bilgisidir.
            "extendedAgreedDeliveryDate": 1615296319000, // satıcı ek süre istedikten sonra hesaplanan yeni süredir. Ek süre girilmemişse null dönecektir.
            "agreedDeliveryExtensionStartDate": 1615296319000, // ek süre girilebilmeye başladığı tarih / agreedDeliveryDateExtendible false ise null dönecektir.
            "agreedDeliveryExtensionEndDate": 1615296319000, // ek süre girilebilmesi için son tarih / agreedDeliveryDateExtendible false ise null dönecektir.
            "invoiceLink": "",
            "fastDelivery": true,
            "fastDeliveryType": "FastDelivery", // Haziran 2022'den itibaren bu alan body içerisinde dönmeye başlayacaktır.
            "originShipmentDate": 1542790350607, // Siparişin ilgili satıcıya aktarılma tarihidir. Muadil ürün süreçlerinde orderDate ile farklı olacağından bu alanın baz alınması gerekmektedir.
            "lastModifiedDate": 1641210225935, // Sipariş paket statüsünün son güncellenme tarihidir.
            "commercial": true, // Kurumsal fatura olmadığı durumda commercial=false dönecektir.
            "deliveredByService": false, // Yetkili servis ile gönderim yaptığınız durumda true değeri dönecektir.
            "micro": true, // Alan değeri true olduğunda ilgili sipariş mikro ihracat siparişi anlamına gelmektedir.
            "giftBoxRequested": true, // Alan değeri true olduğunda ilgili sipariş için müşterinin hediye paketi talebi vardır.
            "etgbNo": "243414X001232", // micro true olduğunda etgbNo alanı için bilgi dönecektir.
            "etgbDate": 1705089600000, // micro true olduğunda etgbDate alanı için bilgi dönecektir.
            "3pByTrendyol": false,
            "containsDangerousProduct": true // micro ihracat siparişlerinde satıcıya gelen siparişte paket içerisinde herhangi bir tehlikeli ürün varsa pil, parfüm vb. gibi, true dönecektir.
        }
    ]
}
```

---

## Validation Rules

### OrderDto
- `content`: Zorunlu, en az bir adet `OrderContentDto` içermelidir.

### OrderContentDto
- `customerEmail`: Zorunlu, geçerli bir e-posta adresi olmalıdır.
- `orderNumber`: Zorunlu.
- `grossAmount`: Zorunlu, 0’dan büyük olmalıdır.
- `totalPrice`: Zorunlu, 0’dan büyük olmalıdır.
- `currencyCode`: Zorunlu.
- `shipmentAddress`: Zorunlu, geçerli bir adres olmalıdır (bkz. ShipmentAddressDto).
- `lines`: Zorunlu, en az bir ürün içermelidir (bkz. OrderLineDto).

### OrderLineDto
- `sku`: Zorunlu, boş olamaz. `SKU boş olamaz`
- `quantity`: Zorunlu, 0’dan büyük olmalıdır. `Adet 0'dan büyük olmalı`
- `price`: 0 veya daha büyük olmalıdır.
- `productName`: Zorunlu.
- `productCode`: Zorunlu, 0’dan büyük olmalıdır.
- `currencyCode`: Zorunlu.

### ShipmentAddressDto
- `firstName`, `lastName`, `address1`, `city`, `district`, `postalCode`, `countryCode`, `fullAddress`: Her biri zorunludur ve boş olamaz.

---

## Response

### Success - 201 Created

```json
{
  "message": "Order Created",
  "orderId": "ORDER-0001"
}
```

### Failure - 400 Bad Request

 

```json
{
  "error": "customerEmail must be a valid email address."
}
```

---

## Error Handling

- Doğrulama hataları (validation errors): `400 Bad Request`

- Sistem hataları: `500 Internal Server Error`

---

## Notes

- Her sipariş `guest customer` olarak oluşturulur.
- SKU doğrulaması yapılır. Mevcut olmayan ürünler siparişi geçersiz kılar.
- Başarılı işlemlerde sipariş oluşturulur ve sipariş numarası döndürülür.