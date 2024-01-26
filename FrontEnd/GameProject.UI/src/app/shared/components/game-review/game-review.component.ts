import {Component, Input} from '@angular/core';
import {GameReview} from "../../models/bussiness/game-reviews/game-review";
import {ScoreColorService} from "../../../core/services/score-color.service";

@Component({
  selector: 'app-game-review',
  templateUrl: './game-review.component.html',
  styleUrl: './game-review.component.scss'
})
export class GameReviewComponent {
  @Input({required: true}) review: GameReview;

  constructor(private scoreColorService: ScoreColorService) {
  }

  getColorBasedOnScore(score: number){
    return this.scoreColorService.getColorBasedOnScore(score);
  }
}
