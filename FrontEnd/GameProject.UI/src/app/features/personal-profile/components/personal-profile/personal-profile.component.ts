import {Component, OnInit} from '@angular/core';
import {Observable, of} from "rxjs";
import {User} from "../../../../shared/models/user";
import {AuthenticationService} from "../../../../core/authentication/services/authentication.service";

@Component({
  selector: 'app-personal-profile',
  templateUrl: './personal-profile.component.html',
  styleUrl: './personal-profile.component.scss'
})
export class PersonalProfileComponent implements OnInit{
  currentUser$: Observable<User | null> = of(null);

  constructor(private authenticationService: AuthenticationService) {
  }

  ngOnInit(): void {
    this.currentUser$ = this.authenticationService.currentUser$;
  }
}
