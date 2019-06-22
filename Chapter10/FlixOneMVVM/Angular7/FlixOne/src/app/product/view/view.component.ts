import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import {ProductserviceService} from '../../services/productservice.service';
import {Router} from '@angular/router';
import { Product} from '../../product';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  productLIst: Product[];

  constructor(private productService: ProductserviceService, private router: Router) { }

  ngOnInit() {
    this.loadProducts();
  }
  loadProducts() {
  this.productService.getProducts().subscribe(
  p => {
      this.productLIst = p;
      return p;
  });
  }
  getNavigation(link, id) {
    if (id === '')  {
      this.router.navigate([link]);
    } else {
      this.router.navigate([link + '/' + id]);
    }
  }
}
