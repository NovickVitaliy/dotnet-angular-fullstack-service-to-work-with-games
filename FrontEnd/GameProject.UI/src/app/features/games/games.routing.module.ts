import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {GamesComponent} from "./components/games/games.component";
import {GameInfoComponent} from "./components/game-info/game-info.component";
import {UserGameListComponent} from "./components/user-game-list/user-game-list.component";
import {authenticatedUserGuard} from "../../core/guards/authenticated-user.guard";

const routes: Routes = [
  {path: 'user-list', component: UserGameListComponent, canActivate: [authenticatedUserGuard], pathMatch: 'full'},
  {path: '', component: GamesComponent, pathMatch: 'full'},
  {path: ':id', component: GameInfoComponent, pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GamesRoutingModule {
}
