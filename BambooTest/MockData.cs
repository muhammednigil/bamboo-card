using BambooDomain.DTO;
using BambooDomain.Requests;
using BambooDomain.Responses;
using BambooService;
using System;
using System.Collections.Generic;
using System.Text;

namespace BambooUnitTest
{
    public static class MockData
    {
        public static CatalogResponse CatalogResponse()
        {
            return new CatalogResponse
            {
                Brands = new List<BrandDTO>()
                {
                    new BrandDTO
                    {
                        Name = "eBay Gift Card",
                        CountryCode = "US",
                        CurrencyCode = "USD",
                        Description = "<p>When you give an eBay gift card, you’re creating a world of possibilities for clients, coworkers, and the people you care about. That means whether they’re looking for something brand new, or just brand new to them, you give the easiest way to find it. And with billions of listings from over a million sellers, they can find the right item that’s right for them. Give the gift of all gifts today!</p>\r\n\r\n<p><strong>To use this Gift Card, you must have a U.S. registered eBay account, a PayPal account, and a U.S. shipping address.</strong></p>\r\n",
                        Disclaimer = null,
                        RedemptionInstructions = "<div>\r\n\t<strong>IMPORTANT INSTRUCTIONS</strong></div>\r\n<div>\r\n\t1. To use this Gift Card (Voucher), you must have a U.S. registered eBay account and a U.S. shipping address.&nbsp;</div>\r\n<div>\r\n\t2. This card is subject to full terms and conditions.&nbsp;</div>\r\n<div>\r\n\t3. Treat your eBay Gift Card (Voucher) like cash.&nbsp;</div>\r\n<div>\r\n\t<strong>HOW TO REDEEM?</strong></div>\r\n<div>\r\n\t1. Click on the Redemption URL.</div>\r\n<div>\r\n\t2. Shop at eBay.com online.</div>\r\n<div>\r\n\t3. At checkout, enter the 13-digit redemption code, then click Apply.</div>\r\n<div>\r\n\t4. Click Continue to review and click Confirm and Pay.</div>\r\n<div>\r\n\t<strong>HOW TO BUY eBAY EGIFT CARD (VOUCHER)?</strong></div>\r\n<div>\r\n\teBay eGift Card (Voucher)is available on the <a href=\"https://stores.xoxoday.com/nreach/\">Xoxoday Store website</a>/Mobile application.&nbsp;</div>\r\n<div>\r\n\t1. Visit <a href=\"https://stores.xoxoday.com/nreach/vouchers/description/ebay-gift-card/46818\">Xoxoday Store website/eBay</a>: View and select eBay .</div>\r\n<div>\r\n\t2. Select the preferred denomination and checkout: You can choose the denomination/s of your preference from those available.</div>\r\n<div>\r\n\t3. Pay via Debit/ Credit/ Net Banking or Xoxoday Voucher/Points: Enter your preferred mode of payment and purchase the eGift Card (Voucher).</div>\r\n<div>\r\n\t<strong>SAVE MONEY WITH eBAY</strong></div>\r\n<div>\r\n\tBuying the right things is a tough task. But with eBay you can select anything. This is where eBay reveals their value. Check out for eBay eGift Card (Voucher) save enormously and fulfill your needs.</div>\r\n<div>\r\n\t<strong>EBAY EGIFT CARD (VOUCHER) FOR OCCASIONS</strong></div>\r\n<div>\r\n\tRather than gifting your loved one's dry fruits or sweets, choose eBay eGift Card (Voucher). And give them the chance to choose their own gifts. With eBay eGift Card (Voucher), the probability of them dumping your gifts will become naught. So, go for eBay eGift Card (Voucher) for Mother's Day, Father's Day, Children's Day, Valentine's Day, your Anniversary or someones Birthday. Your loved ones will consider you thoughtful and you will be getting better gifts on your birthday.</div>\r\n<div>\r\n\t<strong>EBAY EGIFT CARD (VOUCHER) FOR CORPORATE GIFTING</strong></div>\r\n<div>\r\n\tCannot think of one useful item for corporate gifts? How about eBay eGift Card (Voucher) for your employees, clients and partners You give them the option of using the gift to buy anything for themselves or for their loved ones. Use eBay eGift Card (Voucher), and you will remove the possibility of your gift ending in the bin.&nbsp;</div>\r\n<div>\r\n\t<strong>FREQUENTLY ASKED QUESTIONS</strong></div>\r\n<div>\r\n\t<strong>How can I return/cancel eBay eGift Card (Voucher) which I have redeemed?</strong></div>\r\n<div>\r\n\tRegret that it is not possible. EGift Card (Voucher) once redeemed/bought cannot be cancelled or returned.</div>\r\n<div>\r\n\t<strong>Where can I use my eBay eGift Card (Voucher)?</strong></div>\r\n<div>\r\n\tYou can use your eBay eGift Card (Voucher) online.&nbsp;</div>\r\n<div>\r\n\t<strong>Can I buy an eBay&nbsp; eGift Card (Voucher) using my XOXO VOUCHER/POINTS?</strong></div>\r\n<div>\r\n\tYes, you can buy an eBay eGift Card (Voucher) using XOXO VOUCHER/POINTS.</div>\r\n<div>\r\n\t<strong>How can I know the status of my eBay eGift Card (Voucher) (Vouchers)?</strong></div>\r\n<div>\r\n\tYes of course! Enter your eGift Card (Voucher) code in the Voucher Detail section. You will know the status of your eBay e-Gift Card (Voucher)or visit <a href=\"https://plum-support.xoxoday.com/support/home\">https://plum-support.xoxoday.com/support/home</a></div>\r\n<div>\r\n\t&nbsp;</div>\r\n",
                        Terms = null,
                        LogoUrl = "https://res.cloudinary.com/dyyjph6kx/image/upload/gift_vouchers/image/phpgVnQW1_lmmxp5.jpg",
                        ModifiedDate = new DateTime(),
                        Products = new List<ProductDTO>()
                        {
                            new ProductDTO
                            {
                                Id =  62373,
                                Name = "eBay Gift Card",
                                MinFaceValue = 50.0000,
                                MaxFaceValue = 50.0000,
                                Count = 0,
                                ModifiedDate =  Convert.ToDateTime("2021-03-19T07:19:59.6319295"),
                                Price = new PriceDTO
                                {
                                    Min =  52.0000,
                                    Max = 52.0000,
                                    CurrencyCode = "USD"
                                }
                            }
                        }
                    }
                }
            };
        }

        public static AccountResponse AccountResponse()
        {
            return new AccountResponse
            {
                Accounts = new List<AccountDTO>()
                {
                    new AccountDTO
                    {
                        Id = 3131,
                        Currency =  "USD",
                        Balance = 100000.0000,
                        IsActive = true
                    }
                }
            };
        }

        public static OrderDetailResponse OrderDetailResponse(string requestId)
        {
            if(requestId == "ae05a22b-e995-49fa-9826-998ff8176a51")
            {
                return new OrderDetailResponse
                {
                    OrderId = 11024,
                    RequestId = "ae05a22b-e995-49fa-9826-998ff8176a51",
                    Status = "Processing",
                    Total = 0,
                    CreatedDate = Convert.ToDateTime("2021-07-28T04:17:39.7431812"),
                    Failures = new List<FailureDTO>(),
                    Items = new List<Item>()
                {
                    new Item
                    {
                        BrandCode = null,
                        ProductId = 24214,
                        ProductFaceValue = 50.0000,
                        Quantity = 1,
                        PictureUrl = "https://res.cloudinary.com/dyyjph6kx/image/upload/gift_vouchers/image/phpgVnQW1_lmmxp5.jpg",
                        CountryCode = "US",
                        CurrencyCode = "USD",
                        Cards = new List<CardDTO>(),
                        Failures = new List<FailureDTO>()
                    }
                }
                };
            }
            return new OrderDetailResponse
            {
                Errors = "{\"requestId\":[\"The value 'ae05a22b-e995-49fa-9826-998ff8176a51s' is not valid.\"]}".ToJObject(),
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "One or more validation errors occurred.",
                Status = "400",
                TraceId = "|5d17a589-4bf43c88dd2d4bcd."
            };
        }

        public static string OrderResponse(OrderRequest orderRequest)
        {
            return orderRequest.RequestId;
        }
    }
}
