import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GamesComponent } from './components/games/games.component';
import {GamesRoutingModule} from "./games.routing.module";
import { PlatformsFiltersComponent } from './components/platforms-filters/platforms-filters.component';



@NgModule({
  declarations: [
    GamesComponent,
    PlatformsFiltersComponent
  ],
  imports: [
    CommonModule,
    GamesRoutingModule
  ]
})
export class GamesModule { }
