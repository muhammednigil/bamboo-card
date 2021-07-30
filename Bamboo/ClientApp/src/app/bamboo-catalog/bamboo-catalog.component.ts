import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BrandDTO, ProductDTO } from '../../models/service-model';
import { BambooServiceService } from '../bamboo-service.service'

@Component({
  selector: 'app-bamboo-catalog',
  templateUrl: './bamboo-catalog.component.html',
  styleUrls: ['./bamboo-catalog.component.css']
})
export class BambooCatalogComponent {
  public brands: BrandDTO[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private bs: BambooServiceService) {
    http.get<BrandDTO[]>(baseUrl + 'api/Catalog').subscribe(result => {
      this.brands = result["brands"];
    }, error => console.error(error));
  }

  onAddToShoppingList(brand: BrandDTO, product: ProductDTO) {
    this.bs.addOrderProduct(brand, product);
  }
}



