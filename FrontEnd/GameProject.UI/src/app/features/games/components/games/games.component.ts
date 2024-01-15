import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {GameMainInfo} from "../../../../shared/models/game-main-info";
import {GamesResearcherService} from "../../../../core/services/games-researcher.service";
@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrl: './games.component.scss'
})
export class GamesComponent implements OnInit {
  @ViewChild('searchString', {static: true}) searchStringInput: ElementRef | null = null;
  games: GameMainInfo[] = [];
  chosenPlatformsForFiltering: number[] = [];

  constructor(private gamesResearcher: GamesResearcherService) {
  }
  setPlatformForFiltering(platforms: number[]){
    this.chosenPlatformsForFiltering = platforms;
  }

  ngOnInit(): void {
    this.loadGames();
  }

  loadGames(){
    this.gamesResearcher.getGames({
      pageNumber: 1,
      pageSize:32,
      genres: [],
      platforms: [],
      searchString: ''
    }).subscribe({
      next: response => {
        this.games = response;
      }
    });
  }

  searchGames(){
    this.gamesResearcher.getGames({
      searchString: this.searchStringInput?.nativeElement?.value,
      genres: [],
      platforms: this.chosenPlatformsForFiltering,
      pageNumber: 1,
      pageSize: 32
    })
      .subscribe({
        next: response => {
          this.games = response;
        }
      })
  }
}
