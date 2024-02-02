import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {GameStore} from "../../shared/models/rawg-api/game-stores/game-store";
import {environment} from "../../../environments/environment.development";

@Injectable({
  providedIn: 'root'
})
export class GameStoreResearcherService {

  constructor(private http: HttpClient) { }

  getStoresForGame(gameId: number){
    return this.http.get<GameStore[]>(`${environment.apiUrl}games/${gameId}/stores`);
  }
}
