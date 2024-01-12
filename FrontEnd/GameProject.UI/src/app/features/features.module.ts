import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {NavbarModule} from "./navbar/navbar.module";
import {PersonalProfileModule} from "./personal-profile/personal-profile.module";
import {HomeModule} from "./home/home.module";



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    NavbarModule,
    PersonalProfileModule,
    HomeModule
  ],
  exports: [
    NavbarModule,
    PersonalProfileModule,
    HomeModule
  ]
})
export class FeaturesModule { }
