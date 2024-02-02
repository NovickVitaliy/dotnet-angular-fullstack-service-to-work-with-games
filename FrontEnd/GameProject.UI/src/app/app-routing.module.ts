import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {AppComponent} from "./app.component";
import {authenticatedUserGuard} from "./core/guards/authenticated-user.guard";

const routes: Routes = [
  {path: 'home', loadChildren: () => import('./features/home/home.module').then(m => m.HomeModule)},
  {path: 'auth', loadChildren: () => import('./core/authentication/authentication.module').then(m => m.AuthenticationModule)},
  {path: 'profile', loadChildren: () => import('./features/personal-profile/personal-profile.module').then(m => m.PersonalProfileModule), canActivate: [authenticatedUserGuard]},
  {path: 'games', loadChildren: () => import('./features/games/games.module').then(m => m.GamesModule)},
  {path: 'news', loadChildren: () => import('./features/news/news.module').then(m => m.NewsModule)},
  {path: '**', redirectTo: '/home', pathMatch: "full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {scrollPositionRestoration: 'disabled'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
