import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsComponent } from './components/news/news.component';
import {RouterLink} from "@angular/router";
import {NewsRoutingModule} from "./news.routing.module";



@NgModule({
  declarations: [
    NewsComponent
  ],
  imports: [
    CommonModule,
    RouterLink,
    NewsRoutingModule
  ]
})
export class NewsModule { }
