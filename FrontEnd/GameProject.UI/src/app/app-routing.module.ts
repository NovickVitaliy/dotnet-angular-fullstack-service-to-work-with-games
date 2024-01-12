import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AppComponent} from "./app.component";

const routes: Routes = [
  {path: 'home', loadChildren: () => import('./features/home/home.module').then(m => m.HomeModule)},
  {path:'auth', loadChildren: () => import('./core/authentication/authentication.module').then(m => m.AuthenticationModule)},
  {path: 'profile', loadChildren: () => import('./features/personal-profile/personal-profile.module').then(m => m.PersonalProfileModule)},
  {path: '**', redirectTo: '/', pathMatch: "full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
