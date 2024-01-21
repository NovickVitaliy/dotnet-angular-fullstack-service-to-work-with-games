import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GamesComponent } from './components/games/games.component';
import {GamesRoutingModule} from "./games.routing.module";
import { PlatformsFiltersComponent } from './components/platforms-filters/platforms-filters.component';
import {SharedModule} from "../../shared/shared.module";
import { GenresFiltersComponent } from './components/genres-filters/genres-filters.component';
import { GameInfoComponent } from './components/game-info/game-info.component';
import { ListModalComponent } from './components/list-modal/list-modal.component';
import {FormsModule} from "@angular/forms";
import { UserGameListComponent } from './components/user-game-list/user-game-list.component';
import { UserGameListItemComponent } from './user-game-list-item/user-game-list-item.component';



@NgModule({
  declarations: [
    GamesComponent,
    PlatformsFiltersComponent,
    GenresFiltersComponent,
    GameInfoComponent,
    ListModalComponent,
    UserGameListComponent,
    UserGameListItemComponent
  ],
  imports: [
    CommonModule,
    GamesRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class GamesModule { }
