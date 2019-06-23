import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {ProductserviceService} from '../../services/productservice.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  productForm: FormGroup;
  categoryId: '891872e6-5824-4096-ad42-b67408cddba0'; // Default category
  constructor(private productService: ProductserviceService, private router: Router, private formBuilder: FormBuilder) {
    this.productForm = this.formBuilder.group({
      name: ['', Validators.required],
      desc: ['', Validators.compose([Validators.required, Validators.minLength(10), Validators.maxLength(1000)])],
      price: ['', Validators.compose([Validators.required])],
    });
  }
  ngOnInit() {}

  saveProduct(values) {
    const p = {
      productName: values.name,
      productDescription: values.desc,
      productPrice: values.price,
      categoryId: '891872e6-5824-4096-ad42-b67408cddba0'
    };
    this.productService.createProduct(p).subscribe(result => {
      this.router.navigate(['/products']);
    });
  }
  navigation(link) {
    this.router.navigate([link]);
  }

}
