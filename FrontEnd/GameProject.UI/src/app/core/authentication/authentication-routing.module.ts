import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {RegisterComponent} from "./register/register.component";
import {LoginComponent} from "./login/login.component";
import {ConfigureAccountComponent} from "./configure-account/configure-account.component";
import {configureGuard} from "../guards/configure.guard";
import {ConfirmEmailComponent} from "./confirm-email/confirm-email.component";
import {confirmEmailGuard} from "../guards/confirm-email.guard";

const routes: Routes = [
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'configure', component: ConfigureAccountComponent, canActivate: [configureGuard]},
  {path: 'confirm-email', component: ConfirmEmailComponent, canActivate: [confirmEmailGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule {
}
