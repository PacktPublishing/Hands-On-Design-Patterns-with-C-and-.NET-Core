import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import {Product} from '../product';
@Injectable({
  providedIn: 'root'
})
export class ProductserviceService {
  // base api url - should not hard-code here
  // should come from config files
  public apiurl = 'http://localhost:59712/api/product/';
  // public apiurl = 'http://localhost:5000/api/product/';
  constructor(private http: HttpClient) { }
  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiurl + 'productlist');
  }
getProductDetails(id) {
  return this.http.get(this.apiurl + 'view_one.php?id=' + id);
}
createProduct(data) {
  return this.http.post(this.apiurl + 'create.php', data);
}
updateProduct(data) {
  return this.http.post(this.apiurl + 'update.php', data);
}
deleteProduct(id) {
  return this.http.get(this.apiurl + 'delete.php?id=' + id);
}

}
