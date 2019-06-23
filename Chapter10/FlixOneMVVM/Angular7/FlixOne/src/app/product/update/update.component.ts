import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import {Router, ActivatedRoute} from '@angular/router';
import {ProductserviceService} from '../../services/productservice.service';
import { Product } from 'src/app/product';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  productForm: FormGroup;
  productID: any;
  catID: any;
  productData: Product;
  constructor(private productService: ProductserviceService,
              private router: Router,
              private formBuilder: FormBuilder,
              private actRoute: ActivatedRoute) {
    this.productForm = this.formBuilder.group({
      name: ['', Validators.required],
      desc: ['', Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(1000)])],
      price: ['', Validators.compose([Validators.required])],
    });
    // this.productForm.controls.name.setValue(this.productData.productName);
  }

  ngOnInit() {
    this.productID = this.actRoute.snapshot.params.id;
    this.loadProductDetails(this.productID);
    this.catID = this.productData.categoryId;
  }
  loadProductDetails(productID) {
    this.productService.getProductDetails(productID).subscribe(product => {
      this.productData = product;
      this.productForm.setValue({
        name: product.productName,
        desc: product.productDescription,
        price: product.productPrice
      });
    });
  }
  saveProduct(values) {
    const p = {
      productId: this.productID,
      categoryId: this.catID,
      productName: values.name,
      productDescription: values.desc,
      productPrice: values.price
    };
    this.productService.updateProduct(this.productID, p).subscribe(result => {
      this.router.navigate(['']);
    });
  }
  navigation(link) {
    this.router.navigate([link]);
  }
}
