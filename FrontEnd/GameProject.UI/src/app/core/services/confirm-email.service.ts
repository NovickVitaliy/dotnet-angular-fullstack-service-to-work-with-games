import { Injectable } from '@angular/core';
import {SendConfirmEmailMessageRequest} from "../../shared/models/dtos/identity/send-confirm-email-message-request";
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment.development";
import {ConfirmEmailRequest} from "../../shared/models/dtos/identity/confirm-email-request";

@Injectable({
  providedIn: 'root'
})
export class ConfirmEmailService {
  constructor(private httpClient: HttpClient) { }

  sendConfirmEmailMessage(sendConfirmEmailMessageRequest: SendConfirmEmailMessageRequest){
    return this.httpClient.post(`${environment.apiUrl}EmailConfirmation/SendConfirmEmailMessage`, sendConfirmEmailMessageRequest);
  }

  confirmEmail(confirmEmailRequest: ConfirmEmailRequest){
    return this.httpClient.post(`${environment.apiUrl}EmailConfirmation/ConfirmEmail`, confirmEmailRequest);
  }
}
