import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {GamesComponent} from "./components/games/games.component";
import {GameInfoComponent} from "./components/game-info/game-info.component";

const routes: Routes = [
    {path: '', component: GamesComponent},
    {path: ':id', component: GameInfoComponent}
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class GamesRoutingModule {
}
