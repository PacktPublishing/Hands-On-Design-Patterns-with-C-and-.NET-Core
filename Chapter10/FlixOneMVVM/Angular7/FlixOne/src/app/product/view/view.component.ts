import { Component, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import {ProductserviceService} from '../../services/productservice.service';
import {Router} from '@angular/router';
import { Product} from '../../product';
declare var $;

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  productLIst: Observable<Product[]>;
  constructor(private productService: ProductserviceService, private router: Router) { }

  ngOnInit() {
    this.loadProducts();
  }
  loadProducts() {
    this.productLIst = this.productService.getProducts();
  }
  // loadProducts() {
  //   this.productService.getProducts().subscribe(
  //       productData => {
  //         this.products = productData;
  //         console.log(this.products);
  //        // this.dataTable = $(this.Table.nativeElement);
  //         // setTimeout(() => {this.dataTable.DataTable(); }, 2000);
  //       }
  //   );
  // }

  getNavigation(link, id) {
    if (id === '')  {
        this.router.navigate([link]);
    } else {
        this.router.navigate([link + '/' + id]);
    }
}
}
