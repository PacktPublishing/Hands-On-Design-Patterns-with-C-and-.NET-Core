import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import {ViewComponent} from './product/view/view.component';
import {CreateComponent} from './product/create/create.component';
import {UpdateComponent} from './product/update/update.component';
import {ReadComponent} from './product/read/read.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'products', component: ViewComponent},
  {path: 'create', component: CreateComponent},
  {path: 'update/:id', component: UpdateComponent},
  {path: 'view/:id', component: ReadComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
