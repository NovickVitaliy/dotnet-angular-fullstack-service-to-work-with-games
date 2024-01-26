import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {GameAllInfo} from "../../../../shared/models/rawg-api/games/game-all-info";
import {GamesResearcherService} from "../../../../core/services/games-researcher.service";
import {ScoreColorService} from "../../../../core/services/score-color.service";
import {GameScreenshot} from "../../../../shared/models/rawg-api/games/game-screenshot";
import {forkJoin, Observable} from "rxjs";
import {GameTrailer} from "../../../../shared/models/rawg-api/games/game-trailer";
import {AuthenticationService} from "../../../../core/authentication/services/authentication.service";
import {User} from "../../../../shared/models/user";
import {GameReview} from "../../../../shared/models/bussiness/game-reviews/game-review";
import {GameReviewerService} from "../../../../core/services/game-reviewer.service";
import {PagedResult} from "../../../../shared/models/shared/paged-result";

@Component({
  selector: 'app-game-info',
  templateUrl: './game-info.component.html',
  styleUrl: './game-info.component.scss'
})
export class GameInfoComponent implements OnInit {
  gameId: number;
  game: GameAllInfo | null;
  gameScreenshots: GameScreenshot[];
  gameTrailers: GameTrailer[];
  currentUser$: Observable<User | null>
  reviews: PagedResult<GameReview>;

  constructor(private activatedRoute: ActivatedRoute,
              private gamesResearcher: GamesResearcherService,
              private colorScoreService: ScoreColorService,
              private authenticationService: AuthenticationService,
              private gameReviewerService: GameReviewerService) {

  }

  ngOnInit(): void {
    this.gameId = +this.activatedRoute.snapshot.paramMap.get("id");
    this.loadGame();
    this.currentUser$ = this.authenticationService.currentUser$;
  }

  private loadGame() {
    forkJoin({
      gameData: this.gamesResearcher.getGameInfo(this.gameId),
      gameScreenshots: this.gamesResearcher.getGamesScreenshots(this.gameId),
      gameTrailers: this.gamesResearcher.getGamesTrailers(this.gameId),
      reviews: this.gameReviewerService.getReviewsForGame({gameRawgId: this.gameId, page: 1, itemsPerPage: 10})
    }).subscribe({
      next: response => {
        this.game = response.gameData;
        this.gameScreenshots = response.gameScreenshots;
        this.gameTrailers = response.gameTrailers;
        this.reviews = response.reviews;
      }
    })
  }

  getColorBasedOnScore(score: number) {
    return this.colorScoreService.getColorBasedOnScore(score);
  }

  addReview(newReview: GameReview) {
    if (this.reviews.items.length < this.reviews.itemsPerPage) {
      this.reviews.items.push(newReview);
    }
  }

  loadNextPageOfReviews(){
    this.gameReviewerService.getReviewsForGame({page: this.reviews.currentPage + 1, itemsPerPage: 10, gameRawgId:this.gameId})
      .subscribe({
        next: reviews => {
          this.reviews = reviews;
        }
      });
  }
}
