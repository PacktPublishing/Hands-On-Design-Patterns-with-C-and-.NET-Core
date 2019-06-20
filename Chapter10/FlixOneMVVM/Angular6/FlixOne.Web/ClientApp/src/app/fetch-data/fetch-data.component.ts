import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: Products[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Products[]>(baseUrl + 'api/SampleData/GetProducts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface Products {
  productName: string;
  catname: string;
  productPrice: number;
  productDescription: string;
}
