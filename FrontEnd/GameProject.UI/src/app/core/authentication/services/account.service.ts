import { Injectable } from '@angular/core';
import {environment} from "../../../../environments/environment.development";
import {HttpClient} from "@angular/common/http";
import {RegisterRequest} from "../../../shared/models/register-request";
import {BaseResponse} from "../../../shared/models/base-response";
import {AuthenticationResponse} from "../../../shared/models/authentication-response";
import {LoginRequest} from "../../../shared/models/login-request";
import {ConfigureAccountRequest} from "../../../shared/models/configure-account-request";

@Injectable({
  providedIn: 'any'
})
export class AccountService {

  constructor(private http: HttpClient) {}

  register(registerRequest: RegisterRequest){
    console.log(registerRequest);
    return this.http.post<BaseResponse<AuthenticationResponse>>(environment.apiUrl + 'Account/Register', registerRequest);
  }

  login(loginRequest: LoginRequest){
    return this.http.post<BaseResponse<AuthenticationResponse>>(environment.apiUrl + 'Account/Login', loginRequest);
  }

  configureAccount(configureAccountRequest: ConfigureAccountRequest){
    return this.http.post<BaseResponse<void>>(environment.apiUrl + 'Account/ConfigureAccount', configureAccountRequest);
  }
}
