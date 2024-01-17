import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {GamingPlatform} from "../../shared/models/rawg-api/platforms/gaming-platform";
import {environment} from "../../../environments/environment.development";

@Injectable({
  providedIn: 'root'
})
export class PlatformsResearcherService {

  constructor(private http: HttpClient) { }

  getAllPlatforms(){
    return this.http.get<GamingPlatform[]>(`${environment.apiUrl}ResearchPlatforms/AllGamingPlatforms`);
  }
}
