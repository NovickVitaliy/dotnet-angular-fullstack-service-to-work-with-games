import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {GameCardItem} from "../../shared/models/game-card-item";
import {environment} from "../../../environments/environment.development";
import {map} from "rxjs";

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

}
