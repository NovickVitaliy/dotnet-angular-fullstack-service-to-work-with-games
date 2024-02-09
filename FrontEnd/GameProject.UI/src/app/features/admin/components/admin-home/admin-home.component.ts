import {Component, OnInit} from '@angular/core';
import {Observable} from "rxjs";
import {User} from "../../../../shared/models/user";
import {AuthenticationService} from "../../../../core/authentication/services/authentication.service";

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrl: './admin-home.component.scss'
})
export class AdminHomeComponent implements OnInit{
  currentAdmin$: Observable<User | null> = new Observable<User | null>(null);

  constructor(private authenticationService: AuthenticationService) {
  }

  ngOnInit(): void {
    this.loadAdmin();
  }

  private loadAdmin() {
    this.currentAdmin$ = this.authenticationService.currentUser$;
  }
}
