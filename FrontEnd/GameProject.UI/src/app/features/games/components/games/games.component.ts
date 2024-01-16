import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {GameMainInfo} from "../../../../shared/models/game-main-info";
import {GamesResearcherService} from "../../../../core/services/games-researcher.service";
import {PagedResult} from "../../../../shared/models/dtos/paged-result";
import {GameFilterQuery} from "../../../../shared/models/game-filter-query";
@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrl: './games.component.scss'
})
export class GamesComponent implements OnInit {
  @ViewChild('searchString', {static: true}) searchStringInput: ElementRef | null = null;
  games: PagedResult<GameMainInfo> | null = null;
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
    const filterQuery: GameFilterQuery = {
      pageNumber: 1,
      pageSize:32,
      genres: [],
      platforms: [],
      searchString: ''
    };

    this.getGames(filterQuery);
  }

  searchGames(){
    const filterQuery: GameFilterQuery = {
      searchString: this.searchStringInput?.nativeElement?.value,
      genres: [],
      platforms: this.chosenPlatformsForFiltering,
      pageNumber: 1,
      pageSize: 32
    };

    this.getGames(filterQuery);
  }

  changePage(event: number){
    const filterQuery: GameFilterQuery = {
      searchString: this.searchStringInput?.nativeElement?.value,
      genres: [],
      platforms: this.chosenPlatformsForFiltering,
      pageNumber: event,
      pageSize: 32
    }

    this.getGames(filterQuery);
  }

  getGames(filterQuery: GameFilterQuery){
    this.gamesResearcher.getGames(filterQuery)
      .subscribe({
        next: response => {
          this.games = response;
        }
      })
  }
}
