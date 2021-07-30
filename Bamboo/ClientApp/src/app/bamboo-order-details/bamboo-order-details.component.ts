import { Component, Inject, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { OrderDetails, OrderDetailResponse } from '../../models/service-model';
import {NgbModal, NgbActiveModal, NgbModule} from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-bamboo-order-details',
  templateUrl: './bamboo-order-details.component.html',
  styleUrls: ['./bamboo-order-details.component.css']
})

export class BambooOrderDetailsComponent{
  public orders: OrderDetails[] = new Array();
  public orderDetails: OrderDetailResponse = new OrderDetailResponse();

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    let data: string[] = JSON.parse(localStorage.getItem("requestIds"));
    if(data && data.length > 0){
      data.forEach((e,i) =>{
        var details: OrderDetails = {
            OrderName: `#order-${i+1}`,
            RequestId: e
        }
        this.orders.push(details);
      });
    }
  }

  viewOrder(order: OrderDetails, content){
    //TODO: get detils
    // this.http.get<OrderDetailResponse>(this.baseUrl + 'api/Order/' + order.RequestId).subscribe(result => {
    //   this.orderDetails = result["details"];


    //TODO: open popup


    // }, error => console.error(error));
    
  }
}
