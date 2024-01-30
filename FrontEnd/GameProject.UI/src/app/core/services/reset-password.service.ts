import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {SendResetPasswordRequest} from "../../shared/models/dtos/identity/send-reset-password-request";
import {environment} from "../../../environments/environment.development";
import {ResetPasswordRequest} from "../../shared/models/dtos/identity/reset-password-request";

@Injectable({
  providedIn: 'root'
})
export class ResetPasswordService {

  constructor(private httpClient: HttpClient) { }

  sendResetPasswordMessage(sendResetPasswordMessage: SendResetPasswordRequest){
    return this.httpClient.post(`${environment.apiUrl}ResetPassword/SendResetPasswordMail`, sendResetPasswordMessage);
  }

  resetPassword(resetPasswordRequest: ResetPasswordRequest){
    return this.httpClient.post(`${environment.apiUrl}ResetPassword/ResetPassword`, resetPasswordRequest);
  }
}
