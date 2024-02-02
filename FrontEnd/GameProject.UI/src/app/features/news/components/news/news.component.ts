import { Component } from '@angular/core';
import {GameCardItem} from "../../../../shared/models/rawg-api/games/game-card-item";
import {GamesResearcherService} from "../../../../core/services/games-researcher.service";
import {ThemeService} from "../../../../core/services/theme.service";
import {ScoreColorService} from "../../../../core/services/score-color.service";

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrl: './news.component.scss'
})
export class NewsComponent {
  top10highestRatedGamesOfAllTime: GameCardItem[] = [];

  constructor(private gamesResearcher: GamesResearcherService,
              private themeService: ThemeService,
              private scoreColorService: ScoreColorService) {
  }

  ngOnInit(): void {
    this.get10HighestRatedGamesOfAllTime();
  }

  private get10HighestRatedGamesOfAllTime() {
    this.gamesResearcher.get10HighestRatedGamesOfAllTime()
      .subscribe({
        next: response => {
          this.top10highestRatedGamesOfAllTime = response;
          console.log(this.top10highestRatedGamesOfAllTime);
        },
        error: err => {
        }
      });
  }

  getCurrentTheme() {
    return this.themeService.getCurrentTheme();
  }

  getColorBasedOnScore(score: number){
    return this.scoreColorService.getColorBasedOnScore(score);
  }
}
