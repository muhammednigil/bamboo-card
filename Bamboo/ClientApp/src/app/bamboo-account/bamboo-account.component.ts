import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AccountDTO } from '../../models/service-model';

@Component({
  selector: 'app-bamboo-account',
  templateUrl: './bamboo-account.component.html',
  styleUrls: ['./bamboo-account.component.css']
})
export class BambooAccountComponent {
  public accounts: AccountDTO[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<AccountDTO[]>(baseUrl + 'api/Account').subscribe(result => {
      this.accounts = result["accounts"];
    }, error => console.error(error));
  }
}