import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonalProfileComponent } from './components/personal-profile/personal-profile.component';
import {PersonalProfileRoutingModule} from "./personal-profile-routing.module";



@NgModule({
  declarations: [
    PersonalProfileComponent
  ],
  imports: [
    CommonModule,
    PersonalProfileRoutingModule
  ]
})
export class PersonalProfileModule { }
