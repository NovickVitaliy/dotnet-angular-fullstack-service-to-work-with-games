import {Component, Input, OnDestroy, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {ThemeService} from "../../../../core/services/theme.service";
import {Observable, of} from "rxjs";
import {User} from "../../../../shared/models/user";
import {AccountService} from "../../../../core/authentication/services/account.service";
import {error} from "@angular/compiler-cli/src/transformers/util";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit  {
  @Input() isRegistrationMode: boolean = false;
  currentUser$: Observable<User | null> = of(null);
  currentUser: User | null = null;
  constructor(private router: Router,
              private themeService: ThemeService,
              private accountService: AccountService) {
    this.currentUser$ = this.accountService.currentUser$;
  }
  ngOnInit(): void {
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

  logout(){
    console.log("Logging out")
    this.accountService.logout();
  }

  getCurrentTheme(){
    return this.themeService.getCurrentTheme();
  }
}
