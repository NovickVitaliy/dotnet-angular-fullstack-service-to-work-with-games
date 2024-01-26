import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationComponent } from './components/pagination/pagination.component';
import { GameReviewComponent } from './components/game-review/game-review.component';



@NgModule({
  declarations: [
    PaginationComponent,
    GameReviewComponent
  ],
    exports: [
        PaginationComponent,
        GameReviewComponent
    ],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
