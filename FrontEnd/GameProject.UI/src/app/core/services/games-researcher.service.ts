import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {GameCardItem} from "../../shared/models/rawg-api/games/game-card-item";
import {environment} from "../../../environments/environment.development";
import {map} from "rxjs";
import {GameMainInfo} from "../../shared/models/rawg-api/games/game-main-info";
import {GameFilterQuery} from "../../shared/models/rawg-api/common/game-filter-query";
import {PagedResult} from "../../shared/models/dtos/paged-result";
import {GameAllInfo} from "../../shared/models/rawg-api/games/game-all-info";

@Injectable({
  providedIn: 'root'
})
export class GamesResearcherService {
  cached10highestRatedGamesOfAllTime: GameCardItem[] = [];

  constructor(private http: HttpClient) {
  }

  get10HighestRatedGamesOfAllTime() {
    return this.http.get<GameCardItem[]>(`${environment.apiUrl}ResearchGames/Top10HighestRatedGamesOfAllTime`)
      .pipe(map(games => {
        this.cached10highestRatedGamesOfAllTime.push(...games);
        console.log(games);
        console.log(this.cached10highestRatedGamesOfAllTime)
        console.log("observable")
        return games;
      }));
  }

  getGames(filterQuery: GameFilterQuery) {
    let url: string = `${environment.apiUrl}ResearchGames/Games?pageSize=${filterQuery.pageSize}&pageNumber=${filterQuery.pageNumber}`;

    if(filterQuery.platforms.length > 0){
      for(let i = 0; i < filterQuery.platforms.length; ++i){
        url += `&platforms=${filterQuery.platforms[i]}`;
      }
    }

    if(filterQuery.genres.length > 0){
      for(let i = 0; i < filterQuery.genres.length; ++i)
      url += `&genres=${filterQuery.genres[i]}`;
    }

    if(filterQuery.searchString !== ''){
      url += `&searchString=${filterQuery.searchString}`;
    }

    return this.http.get<PagedResult<GameMainInfo>>(url);
  }

  getGameInfo(gameId: number){
    return this.http.get<GameAllInfo>(`${environment.apiUrl}ResearchGames/GetGameInfo/${gameId}`);
  }
}
