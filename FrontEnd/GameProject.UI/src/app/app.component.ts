import {Component, OnInit} from '@angular/core';
import {NavigationEnd, Router} from "@angular/router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  isRegistrationPage: boolean = false;
  title = 'GameProject.UI';

  constructor(private router: Router) {
  }

  ngOnInit(): void {
    this.router.events.subscribe({
      next: event => {
        if(event instanceof NavigationEnd){
          console.log(event.url);
          this.isRegistrationPage = event.url === '/register';
        }
      }
    });
  }
}
