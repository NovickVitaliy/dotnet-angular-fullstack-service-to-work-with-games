import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ChangeAccountDataRequest} from "../../shared/models/dtos/change-account-data-request";
import {environment} from "../../../environments/environment.development";
import {ChangePasswordRequest} from "../../shared/models/dtos/change-password-request";
import {ChangeProfilePhotoResponse} from "../../shared/models/dtos/change-profile-photo-response";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private httpClient: HttpClient) { }

  changeAccountData(editAccountDataRequest: ChangeAccountDataRequest){
    return this.httpClient.post(`${environment.apiUrl}Account/ChangeAccountData`, editAccountDataRequest);
  }

  changeAccountPassword(changePasswordRequest: ChangePasswordRequest){
    return this.httpClient.post(`${environment.apiUrl}Account/ChangeAccountPassword`, changePasswordRequest);
  }

  changeAccountProfilePicture(file: File){
    const formData = new FormData();
    formData.append('image', file);

    return this.httpClient.post<ChangeProfilePhotoResponse>(`${environment.apiUrl}Account/ChangeAccountProfilePicture`, formData);
  }

  deleteProfilePicture(){
    return this.httpClient.post(`${environment.apiUrl}Account/DeleteAccountProfilePicture`, {});
  }
}
