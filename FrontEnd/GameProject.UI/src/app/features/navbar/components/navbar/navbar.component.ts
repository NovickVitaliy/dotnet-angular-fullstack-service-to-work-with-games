import {Component, Input, OnInit} from '@angular/core';
import {NavigationEnd, Router} from "@angular/router";
import {ThemeService} from "../../../../core/services/theme.service";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit  {
  @Input() isRegistrationMode: boolean = false;

  constructor(private router: Router,
              private themeService: ThemeService) {
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

  changeTheme() {
    let currentTheme = this.themeService.getCurrentTheme();
    currentTheme === 'sony'
      ? this.themeService.setCurrentTheme('microsoft')
      : this.themeService.setCurrentTheme('sony');
  }

  getThemeIcon(){
    let currentTheme = this.themeService.getCurrentTheme();
    return currentTheme === 'sony'
      ? this.themeService.pathToSonyIcon
      : this.themeService.pathToMicrosoftIcon;
  }
}
