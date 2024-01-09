import {Component, OnInit} from '@angular/core';
import {NavigationEnd, Router} from "@angular/router";
import {ThemeService} from "./core/services/theme.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  isRegistrationPage: boolean = false;
  title = 'GameProject.UI';

  constructor(private router: Router,
              private themeService: ThemeService) {
  }

  ngOnInit(): void {
    this.router.events.subscribe({
      next: event => {
        if(event instanceof NavigationEnd){
          console.log(event.url);
          this.isRegistrationPage = event.url === '/auth/register'
                                    || event.url === '/auth/login';
        }
      }
    });
  }

  getTheme(){
    return this.themeService.getCurrentTheme();
  }
}
