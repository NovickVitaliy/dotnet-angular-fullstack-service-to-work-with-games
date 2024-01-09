import {Component, Input, OnInit} from '@angular/core';
import {NavigationEnd, Router} from "@angular/router";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit  {
  @Input() isRegistrationMode: boolean = false;

  constructor(private router: Router) {

  }

  ngOnInit(): void {
    this.router.events.subscribe({
      next: event => {
        if(event instanceof NavigationEnd){
          this.isRegistrationMode = event.url === '/register';
        }
      }
    });
  }
}
