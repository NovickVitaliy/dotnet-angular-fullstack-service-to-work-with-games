import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {GenreMainInfo} from "../../shared/models/genre-main-info";
import {environment} from "../../../environments/environment.development";

@Injectable({
  providedIn: 'root'
})
export class GenresResearcherService {

  constructor(private httpClient: HttpClient) { }

  getGenres(){
    return this.httpClient.get<GenreMainInfo[]>(`${environment.apiUrl}ResearchGenres/GetGenres`);
  }
}
