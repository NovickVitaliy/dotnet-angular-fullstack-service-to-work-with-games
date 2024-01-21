import {Injectable} from '@angular/core';
import {environment} from "../../../../environments/environment.development";
import {HttpClient} from "@angular/common/http";
import {RegisterRequest} from "../../../shared/models/dtos/register-request";
import {BaseResponse} from "../../../shared/models/dtos/base-response";
import {LoginRequest} from "../../../shared/models/dtos/login-request";
import {ConfigureAccountRequest} from "../../../shared/models/dtos/configure-account-request";
import {BehaviorSubject, map, Observable, shareReplay} from "rxjs";
import {User} from "../../../shared/models/user";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private currentUserSource: BehaviorSubject<User | null> = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  userJustRegistered: boolean = false;

  constructor(private http: HttpClient) {
  }

  register(registerRequest: RegisterRequest) {
    return this.http.post<BaseResponse<User>>(environment.apiUrl + 'Authentication/Register', registerRequest).pipe(
      map((response) => {
        const user = response.data;
        if(user){
          this.setCurrentUser(user);
        }
      })
    );
  }

  login(loginRequest: LoginRequest) {
    return this.http.post<BaseResponse<User>>(environment.apiUrl + 'Authentication/Login', loginRequest).pipe(
      map((response) => {
        const user = response.data;
        if(user){
          console.log("Response: "+ JSON.stringify(response));
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
    return this.http.post<BaseResponse<void>>(environment.apiUrl + 'Authentication/ConfigureAccount', configureAccountRequest);
  }

  get currentUserEmail(){
    return this.currentUser$.pipe(map(user => {
      if(user){
        return user.email;
      }
      throw new Error("Could not access user email property");
    }));
  }
}
