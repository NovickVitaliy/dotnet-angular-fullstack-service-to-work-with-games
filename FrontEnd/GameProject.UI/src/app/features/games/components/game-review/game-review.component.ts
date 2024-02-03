import {Component, Input} from '@angular/core';
import {GameReview} from "../../../../shared/models/bussiness/game-reviews/game-review";
import {ScoreColorService} from "../../../../core/services/score-color.service";
import {GameReviewerService} from "../../../../core/services/game-reviewer.service";
import {ToastrService} from "ngx-toastr";
import {AuthenticationService} from "../../../../core/authentication/services/authentication.service";

@Component({
  selector: 'app-game-review',
  templateUrl: './game-review.component.html',
  styleUrl: './game-review.component.scss'
})
export class GameReviewComponent {
  @Input({required: true}) review: GameReview;
  @Input({required: true}) isEditable: boolean;

  constructor(private scoreColorService: ScoreColorService,
              private reviewerService: GameReviewerService,
              private toastr: ToastrService,
              private authenticationService: AuthenticationService) {
  }

  getColorBasedOnScore(score: number){
    return this.scoreColorService.getColorBasedOnScore(score);
  }

  removeReview(reviewId: string){
    this.reviewerService.deleteGameReview({reviewId: reviewId})
      .subscribe({
        next: _ => {
          this.toastr.success("Review has been successfully deleted");
        }
      });

    this.authenticationService.currentUser$.subscribe({
      next: user => {
        if(user.gameReviews.items.some(re => re.reviewId=== reviewId)){
          user.gameReviews.items = user.gameReviews.items.filter(review => review.reviewId !== reviewId)
        }
        localStorage.setItem('user', JSON.stringify(user));
      }
    })
  }

  editReview(){

  }
}
