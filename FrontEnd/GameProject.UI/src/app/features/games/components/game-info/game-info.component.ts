import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {GameAllInfo} from "../../../../shared/models/rawg-api/games/game-all-info";
import {GamesResearcherService} from "../../../../core/services/games-researcher.service";
import {ScoreColorService} from "../../../../core/services/score-color.service";
import {GameScreenshot} from "../../../../shared/models/rawg-api/games/game-screenshot";
import {forkJoin} from "rxjs";
import {GameTrailer} from "../../../../shared/models/rawg-api/games/game-trailer";

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

  constructor(private activatedRoute: ActivatedRoute,
              private gamesResearcher: GamesResearcherService,
              private colorScoreService: ScoreColorService) {

  }

  ngOnInit(): void {
    this.gameId = +this.activatedRoute.snapshot.paramMap.get("id");
    this.loadGame();
  }

  private loadGame() {
    forkJoin({
      gameData: this.gamesResearcher.getGameInfo(this.gameId),
      gameScreenshots: this.gamesResearcher.getGamesScreenshots(this.gameId),
      gameTrailers: this.gamesResearcher.getGamesTrailers(this.gameId)
    }).subscribe({
    next: response => {
      this.game = response.gameData;
      this.gameScreenshots = response.gameScreenshots;
      this.gameTrailers = response.gameTrailers;
      console.log(response.gameTrailers)
    }
    })
  }

  getColorBasedOnScore(score: number){
    return this.colorScoreService.getColorBasedOnScore(score);
  }
}
