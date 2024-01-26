import {Component, ElementRef, EventEmitter, Input, Output, ViewChild} from '@angular/core';
import {GameReviewerService} from "../../../../core/services/game-reviewer.service";
import {Toast, ToastrService} from "ngx-toastr";
import {CreateGameReviewRequest} from "../../../../shared/models/dtos/bussiness/game-review/create-game-review-request";
import {Observable, take} from "rxjs";
import {User} from "../../../../shared/models/user";
import {GameReview} from "../../../../shared/models/bussiness/game-reviews/game-review";

@Component({
  selector: 'app-game-review-modal',
  templateUrl: './game-review-modal.component.html',
  styleUrl: './game-review-modal.component.scss'
})
export class GameReviewModalComponent {
  reviewMaxLength: number = 300;
  availableCharsForReview: number = this.reviewMaxLength;
  scores: number[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
  reviewScore: number | null = 5;
  @ViewChild("reviewTextArea") reviewerTextArea: ElementRef;
  @Input({required: true}) gameName: string;
  @Input({required: true}) gameRawgId: number;
  @Input({required: true}) currentUser$: Observable<User>;
  @Output() newReview: EventEmitter<GameReview> = new EventEmitter<GameReview>();

  constructor(private gameReviewerService: GameReviewerService,
              private toastr: ToastrService) {
  }

  addReview() {
    const review = this.reviewerTextArea.nativeElement.value;
    console.log(`Review: ${review}`)
    console.log(`Score: ${this.reviewScore}`)
    if (review && this.reviewScore) {
      const createReviewRequest: CreateGameReviewRequest = {
        review: review,
        gameRawgId: this.gameRawgId,
        score: this.reviewScore,
        gameName: this.gameName
      }
      this.gameReviewerService.createGameReview(createReviewRequest)
        .subscribe({
          next: newReview => {
            this.currentUser$.pipe(take(1))
              .subscribe({
                next: user => {
                  user.gameReviews.push(newReview);
                }
              })
            this.newReview.emit(newReview)
          }
        })
    } else {
      this.toastr.error("Fill the needed info for publishing your review");
    }
  }

  setReviewScore(score: number) {
    this.reviewScore = score;
  }

  calculateAvailableChars(event: any){
    this.availableCharsForReview = this.reviewMaxLength - event.target.value.length;
  }
}
