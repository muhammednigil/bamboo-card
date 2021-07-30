import { Injectable } from '@angular/core';
import { Subject } from 'rxjs/Subject';
import { OrderProduct, BrandDTO, ProductDTO } from '../models/service-model';

@Injectable({
  providedIn: 'root'
})
export class BambooServiceService {

  productsChanged = new Subject<OrderProduct[]>();
  private orderProducts: OrderProduct[] = new Array();
  
  getOrderProducts() {
    if(this.orderProducts)
      return this.orderProducts.slice();
    else
      return ;
  }

  getOrderProduct(index: number) {
    return this.orderProducts[index];
  }

  addOrderProduct(brand: BrandDTO, product: ProductDTO) {
    var orderProduct: OrderProduct =  {
      ProductId : product.id,
      Quantity : parseInt(product.qty.toString()),
      // Value: product.qty * product.maxFaceValue,
      Value: product.maxFaceValue,
      BrandName : brand.name,
      ProductName : product.name
    };

    var index = -1;
    if(this.orderProducts)
      index = this.orderProducts.findIndex(f=> f.ProductId == orderProduct.ProductId);
    if(index > -1){
      this.updateOrderProduct(index, orderProduct);
    }
    else{
      this.orderProducts.push(orderProduct);
      this.productsChanged.next(this.orderProducts.slice());
    }
  }

  addOrderProducts(products: OrderProduct[]) {
    this.orderProducts.push(...products);
    this.productsChanged.next(this.orderProducts.slice());
  }

  updateOrderProduct(index: number, newproduct: OrderProduct) {
    this.orderProducts[index] = newproduct;
    this.productsChanged.next(this.orderProducts.slice());
  }

  deleteOrderProduct(index: number) {
    this.orderProducts.splice(index, 1);
    this.productsChanged.next(this.orderProducts.slice());
  }
}
