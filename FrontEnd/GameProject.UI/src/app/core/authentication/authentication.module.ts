import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import {AuthenticationRoutingModule} from "./authentication-routing.module";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { LoginComponent } from './login/login.component';
import { ConfigureAccountComponent } from './configure-account/configure-account.component';
import { ConfirmEmailComponent } from './confirm-email/confirm-email.component';

@NgModule({
  declarations: [
    RegisterComponent,
    LoginComponent,
    ConfigureAccountComponent,
    ConfirmEmailComponent,
  ],
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
  ]
})
export class AuthenticationModule { }
