import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {GameMainInfo} from "../../../../shared/models/rawg-api/games/game-main-info";
import {GamesResearcherService} from "../../../../core/services/games-researcher.service";
import {PagedResult} from "../../../../shared/models/dtos/paged-result";
import {GameFilterQuery} from "../../../../shared/models/rawg-api/common/game-filter-query";
import {GenresResearcherService} from "../../../../core/services/genres-researcher.service";
import {GenreMainInfo} from "../../../../shared/models/rawg-api/genres/genre-main-info";
import {ScoreColorService} from "../../../../core/services/score-color.service";
@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrl: './games.component.scss'
})
export class GamesComponent implements OnInit {
  @ViewChild('searchString', {static: true}) searchStringInput: ElementRef | null = null;
  games: PagedResult<GameMainInfo> | null = null;
  chosenPlatformsForFiltering: number[] = [];
  chosenGenresForFiltering: number[] = [];
  genres: GenreMainInfo[];

  constructor(private gamesResearcher: GamesResearcherService,
              private genresResearcher: GenresResearcherService,
              private scoreColorService: ScoreColorService) {
  }
  setPlatformForFiltering(platforms: number[]){
    this.chosenPlatformsForFiltering = platforms;
  }

  setGenreForFiltering(genres: number[]){
    this.chosenGenresForFiltering = genres;
  }

  ngOnInit(): void {
    this.loadGames();
    this.loadGenres();
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
      genres: this.chosenGenresForFiltering,
      platforms: this.chosenPlatformsForFiltering,
      pageNumber: 1,
      pageSize: 32
    };

    this.getGames(filterQuery);
  }

  changePage(event: number){
    const filterQuery: GameFilterQuery = {
      searchString: this.searchStringInput?.nativeElement?.value,
      genres: this.chosenGenresForFiltering,
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

  private loadGenres() {
    this.genresResearcher.getGenres()
      .subscribe({
        next: genres => {
          this.genres = genres;
        }
      })
  }

  researchGenre(genreId: number){
    //TODO: Implement genre researching
  }

  getColorBasedOnScore(score: number){
    return this.scoreColorService.getColorBasedOnScore(score);
  }
}
