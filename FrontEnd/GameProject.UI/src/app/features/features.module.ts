import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavbarModule} from "./navbar/navbar.module";



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    NavbarModule
  ],
  exports: [NavbarModule]
})
export class FeaturesModule { }
