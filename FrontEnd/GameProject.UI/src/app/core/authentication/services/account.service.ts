import {Injectable} from '@angular/core';
import {environment} from "../../../../environments/environment.development";
import {HttpClient} from "@angular/common/http";
import {RegisterRequest} from "../../../shared/models/register-request";
import {BaseResponse} from "../../../shared/models/base-response";
import {LoginRequest} from "../../../shared/models/login-request";
import {ConfigureAccountRequest} from "../../../shared/models/configure-account-request";
import {BehaviorSubject, map, Observable, shareReplay} from "rxjs";
import {User} from "../../../shared/models/user";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private currentUserSource: BehaviorSubject<User | null> = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  userJustRegistered: boolean = false;

  constructor(private http: HttpClient) {
  }

  register(registerRequest: RegisterRequest) {
    return this.http.post<BaseResponse<User>>(environment.apiUrl + 'Account/Register', registerRequest).pipe(
      map((response) => {
        const user = response.data;
        if(user){
          this.setCurrentUser(user);
        }
      })
    );
  }

  login(loginRequest: LoginRequest) {
    return this.http.post<BaseResponse<User>>(environment.apiUrl + 'Account/Login', loginRequest).pipe(
      map((response) => {
        const user = response.data;
        if(user){
          this.setCurrentUser(user);
        }
        return user;
      })
    )
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    localStorage.setItem('access_token', user.accessToken);
    localStorage.setItem('refresh_token', user.refreshToken);
    this.currentUserSource.next(user);
  }

  logout() {
    localStorage.removeItem('user');
    localStorage.removeItem('access_token');
    localStorage.removeItem('refresh_token');
    this.currentUserSource.next(null);
  }

  configureAccount(configureAccountRequest: ConfigureAccountRequest) {
    return this.http.post<BaseResponse<void>>(environment.apiUrl + 'Account/ConfigureAccount', configureAccountRequest);
  }
}
