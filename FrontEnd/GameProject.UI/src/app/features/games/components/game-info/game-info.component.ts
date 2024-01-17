import {ChangeDetectorRef, Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {GameAllInfo} from "../../../../shared/models/rawg-api/games/game-all-info";
import {GamesResearcherService} from "../../../../core/services/games-researcher.service";

@Component({
  selector: 'app-game-info',
  templateUrl: './game-info.component.html',
  styleUrl: './game-info.component.scss'
})
export class GameInfoComponent implements OnInit {
  gameId: number;
  game: GameAllInfo | null;

  constructor(private activatedRoute: ActivatedRoute,
              private gamesResearcher: GamesResearcherService) {

  }

  ngOnInit(): void {
    this.gameId = +this.activatedRoute.snapshot.paramMap.get("id");
    this.loadGame();
  }

  private loadGame() {
    this.gamesResearcher.getGameInfo(this.gameId)
      .subscribe({
        next: game => {
          this.game = game;
        }
      });
  }
}
