import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationComponent } from './components/pagination/pagination.component';
import { GameReviewComponent } from '../features/games/components/game-review/game-review.component';
import {GamesModule} from "../features/games/games.module";



@NgModule({
  declarations: [
    PaginationComponent
  ],
    exports: [
        PaginationComponent
    ],
  imports: [
    CommonModule,
  ]
})
export class SharedModule { }
