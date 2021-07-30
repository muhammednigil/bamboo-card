import { Component, OnInit, OnDestroy, Inject } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';
import { HttpClient } from '@angular/common/http';
import { OrderProduct, OrderRequest, AccountDTO, OrderResponse } from '../../models/service-model';
import { BambooServiceService } from '../bamboo-service.service'

@Component({
  selector: 'app-bamboo-cart',
  templateUrl: './bamboo-cart.component.html',
  styleUrls: ['./bamboo-cart.component.css']
})
export class BambooCartComponent implements OnInit, OnDestroy {
  orderProducts: OrderProduct[];
  private subscription: Subscription;
  public accounts: AccountDTO[];
  accountId: number;


  constructor(private bs: BambooServiceService, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { 
    http.get<AccountDTO[]>(baseUrl + 'api/Account').subscribe(result => {
      this.accounts = result["accounts"];
      this.accountId = parseInt(this.accounts[0]["id"].toString());
    }, error => console.error(error));
  }

  ngOnInit() {
    this.orderProducts = this.bs.getOrderProducts();
    this.subscription = this.bs.productsChanged
      .subscribe(
        (orderProducts: OrderProduct[]) => {
          this.orderProducts = orderProducts;
        }
      );
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  onDeleteFromShoppingList(op: OrderProduct){
    var index = this.orderProducts.findIndex(f=> f.ProductId == op.ProductId);
    this.bs.deleteOrderProduct(index);
  }

  AccountChangeHandler (event: any) {
    this.accountId = parseInt(event.target.value.toString());
  }

  saveOrder(){
    let requestId = '';

    if(this.orderProducts && this.orderProducts.length > 0){
      
      let body: OrderRequest = {
        AccountId : this.accountId,
        RequestId: '',
        Products: this.orderProducts
      }

      const headers = { 'Content-Type': 'application/json'};
      this.http.post<OrderResponse>(this.baseUrl + 'api/Order', body,{ headers }).subscribe(result => {
        requestId = result["requestId"];
        if(requestId && requestId !== ''){
          let data: string[] = JSON.parse(localStorage.getItem("requestIds"));
          if(!data || data.length == 0)
            data = new Array();
      
          data.push(requestId);
          localStorage.setItem("requestIds", JSON.stringify(data));
          window.location.reload();
        }
      });
  
      
      
    }
  }
}
