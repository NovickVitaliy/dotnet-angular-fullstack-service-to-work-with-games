import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment.development";
import {AddGameToUserListRequest} from "../../shared/models/bussiness/dtos/add-game-to-user-list-request";
import {RemoveGameFromUserListRequest} from "../../shared/models/bussiness/dtos/remove-game-from-user-list-request";
import {ChangeGameStatusRequest} from "../../shared/models/bussiness/dtos/change-game-status-request";

@Injectable({
  providedIn: 'root'
})
export class UserGameListService {

  constructor(private httpClient: HttpClient) { }

  addGameToUserList(addGameToListRequest: AddGameToUserListRequest){
    return this.httpClient.post(`${environment.apiUrl}AccountGameList/AddGameToUserList`, addGameToListRequest);
  }

  removeGameFromUserList(removeGameFromListRequest: RemoveGameFromUserListRequest){
    return this.httpClient.post(`${environment.apiUrl}AccountGameList/RemoveGameFromUserList`, removeGameFromListRequest);
  }

  changeGameStatusInUserList(changeGameStatusInUserListRequest: ChangeGameStatusRequest){
    return this.httpClient.post(`${environment.apiUrl}AccountGameList/ChangeGameStatusInUserList`, changeGameStatusInUserListRequest);
  }
}
