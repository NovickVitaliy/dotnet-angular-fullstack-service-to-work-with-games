import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationComponent } from './components/pagination/pagination.component';



@NgModule({
  declarations: [
    PaginationComponent
  ],
  exports: [
    PaginationComponent
  ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
