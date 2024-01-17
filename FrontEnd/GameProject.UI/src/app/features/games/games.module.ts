import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GamesComponent } from './components/games/games.component';
import {GamesRoutingModule} from "./games.routing.module";
import { PlatformsFiltersComponent } from './components/platforms-filters/platforms-filters.component';
import {SharedModule} from "../../shared/shared.module";
import { GenresFiltersComponent } from './components/genres-filters/genres-filters.component';
import { GameInfoComponent } from './components/game-info/game-info.component';



@NgModule({
  declarations: [
    GamesComponent,
    PlatformsFiltersComponent,
    GenresFiltersComponent,
    GameInfoComponent
  ],
    imports: [
        CommonModule,
        GamesRoutingModule,
        SharedModule
    ]
})
export class GamesModule { }
