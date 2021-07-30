export class OrderDetailResponse{ 
  requestId: string;
  orderId: number; 
  items: Item[]; 
  status: string; 
  createdDate: Date; 
  total: number; 
  type: string; 
  title: string; 
  traceId: string; 
  }

  export class Item{ 
    brandCode: string; 
    productId: number; 
    productFaceValue: number; 
    quantity: number; 
    pictureUrl: string; 
    countryCode: string; 
    currencyCode: string; 
    cards: CardDTO[]; 
    }
    
  
    export class CardDTO{ 
      serialNumber: string; 
      cardCode: string; 
      url: string; 
      pin: string; 
      expirationDate: string; 
      }

export class BrandDTO { 
    name: string; 
    countryCode: string; 
    currencyCode: string; 
    description: string; 
    disclaimer: string; 
    redemptionInstructions: string; 
    terms: string; 
    logoUrl: string; 
    modifiedDate: Date; 
    products: ProductDTO[]; 
    }
    
    export class ProductDTO{ 
      id: number; 
      name: string; 
      minFaceValue: number; 
      maxFaceValue: number; 
      count?: number; 
      price: PriceDTO; 
      modifiedDate: Date; 
      qty: number;
    }
    
    export class PriceDTO{ 
      min: number; 
      max: number; 
      currencyCode: string; 
      }

      export class AccountDTO{ 
        Id: number; 
        Currency: string; 
        Balance: number; 
        IsActive: boolean; 
        }
        
        export class OrderProduct{ 
          ProductId: number; 
          Quantity: number; 
          Value: number; 
          BrandName: string;
          ProductName: string;

        }    
        
        export class OrderResponse{ 
          requestId: string; 
          }

          export class OrderRequest{ 
            RequestId: string; 
            AccountId: number; 
            Products: OrderProduct[]; 
            }
            export class OrderDetails{ 
              RequestId: string; 
              OrderName: string; 
              }