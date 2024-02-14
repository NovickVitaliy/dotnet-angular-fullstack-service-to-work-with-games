import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminHomeComponent } from './components/admin-home/admin-home.component';
import {AdminRoutingModule} from "./admin-routing.module";
import { AddNewsComponent } from './components/add-news/add-news.component';
import {FormsModule} from "@angular/forms";



@NgModule({
  declarations: [
    AdminHomeComponent,
    AddNewsComponent
  ],
    imports: [
        CommonModule,
        AdminRoutingModule,
        FormsModule
    ]
})
export class AdminModule { }
