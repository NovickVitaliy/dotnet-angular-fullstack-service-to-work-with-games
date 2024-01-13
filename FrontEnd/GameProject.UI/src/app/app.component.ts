import {Component, OnInit} from '@angular/core';
import {NavigationEnd, Router} from "@angular/router";
import {ThemeService} from "./core/services/theme.service";
import {AuthenticationService} from "./core/authentication/services/authentication.service";
import {User} from "./shared/models/user";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  isAuthenticationMode: boolean = false;
  title = 'GameProject.UI';

  constructor(private router: Router,
              private themeService: ThemeService,
              private authenticationService: AuthenticationService) {
  }

  ngOnInit(): void {
    this.setupAuthenticationModeCatcher();
    this.setCurrentUser();
  }

  getTheme(){
    return this.themeService.getCurrentTheme();
  }

  setupAuthenticationModeCatcher(){
    this.router.events.subscribe({
      next: event => {
        if(event instanceof NavigationEnd){
          this.isAuthenticationMode = event.url === '/auth/register'
            || event.url === '/auth/login'
            || event.url === '/auth/configure';
        }
      }
    });
  }

  setCurrentUser(){
    let userString = localStorage.getItem('user');
    if(userString){
      const user: User = JSON.parse(userString);
      console.log("app.component.setCurrentUser" + userString)
      console.log({...user});
      this.authenticationService.setCurrentUser(user);
    }
  }
}
