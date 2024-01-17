import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {GameAllInfo} from "../../../../shared/models/rawg-api/games/game-all-info";
import {GamesResearcherService} from "../../../../core/services/games-researcher.service";

@Component({
  selector: 'app-game-info',
  templateUrl: './game-info.component.html',
  styleUrl: './game-info.component.scss'
})
export class GameInfoComponent implements OnInit{
  gameId: number;
  game: GameAllInfo;
  constructor(private activatedRoute: ActivatedRoute,
              private gamesResearcher: GamesResearcherService) {

  }

  ngOnInit(): void {
    this.loadGame();

  }

  private loadGame() {
    this.activatedRoute.params.subscribe({
      next: params =>{
        this.gameId = +params['id'];
      }
    });

    this.gamesResearcher.getGameInfo(this.gameId)
      .subscribe({
        next: game => {
          this.game = game;
        }
      });
  }
}
