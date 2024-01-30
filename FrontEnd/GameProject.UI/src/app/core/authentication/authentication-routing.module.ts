import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {RegisterComponent} from "./register/register.component";
import {LoginComponent} from "./login/login.component";
import {ConfigureAccountComponent} from "./configure-account/configure-account.component";
import {configureGuard} from "../guards/configure.guard";
import {ConfirmEmailComponent} from "./confirm-email/confirm-email.component";
import {confirmEmailGuard} from "../guards/confirm-email.guard";
import {ResetPasswordRequestFormComponent} from "./reset-password-request-form/reset-password-request-form.component";
import {ResetPasswordComponent} from "./reset-password/reset-password.component";
import {resetPasswordGuard} from "../guards/reset-password.guard";

const routes: Routes = [
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'configure', component: ConfigureAccountComponent, canActivate: [configureGuard]},
  {path: 'confirm-email', component: ConfirmEmailComponent, canActivate: [confirmEmailGuard]},
  {path: 'reset-password-request', component: ResetPasswordRequestFormComponent, pathMatch: "full"},
  {path: 'reset-password', component: ResetPasswordComponent, pathMatch: "full", canActivate: [resetPasswordGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthenticationRoutingModule {
}
