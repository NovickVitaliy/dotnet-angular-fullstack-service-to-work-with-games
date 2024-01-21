import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {PersonalProfileComponent} from "./components/personal-profile/personal-profile.component";
import {authenticatedUserGuard} from "../../core/guards/authenticated-user.guard";
import {EditProfileComponent} from "./components/edit-profile/edit-profile.component";
import {authenticationInterceptor} from "../../core/interceptors/authentication.interceptor";
import {EditAccountDataComponent} from "./components/edit-account-data/edit-account-data.component";
import {EditAccountSecurityComponent} from "./components/edit-account-security/edit-account-security.component";

const routes: Routes = [
  {path: '', component: PersonalProfileComponent},
  {
    path: 'edit',
    component: EditProfileComponent,
    children: [
      {path: 'account-data', component: EditAccountDataComponent},
      {path: 'account-security', component: EditAccountSecurityComponent}
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PersonalProfileRoutingModule {
}
