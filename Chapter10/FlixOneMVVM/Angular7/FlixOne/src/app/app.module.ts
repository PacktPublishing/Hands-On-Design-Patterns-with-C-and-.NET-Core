import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ViewComponent } from './product/view/view.component';
import { CreateComponent } from './product/create/create.component';
import { UpdateComponent } from './product/update/update.component';
import { ReadComponent } from './product/read/read.component';

@NgModule({
  declarations: [
    AppComponent,
    ViewComponent,
    CreateComponent,
    UpdateComponent,
    ReadComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
