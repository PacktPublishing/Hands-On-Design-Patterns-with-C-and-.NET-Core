import { Component, OnInit, ViewChild } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
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
  productList: Product[];

  constructor(private productService: ProductserviceService, private router: Router, private domSanitizer: DomSanitizer) { }

  ngOnInit() {
    this.loadProducts();
  }
  loadProducts() {
  this.productService.getProducts().subscribe(
  p => {
      this.productList = p;
      });
  }
  deleteProduct(id: string) {
    this.productService.deleteProduct(id).subscribe(p => {
    this.loadProducts();
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
