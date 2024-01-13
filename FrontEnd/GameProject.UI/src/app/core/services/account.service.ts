import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {EditAccountDataRequest} from "../../shared/models/dtos/edit-account-data-request";
import {environment} from "../../../environments/environment.development";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private httpClient: HttpClient) { }

  editAccountData(editAccountDataRequest: EditAccountDataRequest){
    return this.httpClient.post(`${environment.apiUrl}Account/EditAccountData`, editAccountDataRequest);
  }
}
