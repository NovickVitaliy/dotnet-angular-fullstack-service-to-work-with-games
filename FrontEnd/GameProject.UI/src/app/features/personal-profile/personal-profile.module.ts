import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonalProfileComponent } from './components/personal-profile/personal-profile.component';
import {PersonalProfileRoutingModule} from "./personal-profile-routing.module";
import { EditProfileComponent } from './components/edit-profile/edit-profile.component';
import { EditAccountDataComponent } from './components/edit-account-data/edit-account-data.component';
import { EditAccountSecurityComponent } from './components/edit-account-security/edit-account-security.component';
import {ReactiveFormsModule} from "@angular/forms";



@NgModule({
  declarations: [
    PersonalProfileComponent,
    EditProfileComponent,
    EditAccountDataComponent,
    EditAccountSecurityComponent
  ],
  imports: [
    CommonModule,
    PersonalProfileRoutingModule,
    ReactiveFormsModule
  ]
})
export class PersonalProfileModule { }
