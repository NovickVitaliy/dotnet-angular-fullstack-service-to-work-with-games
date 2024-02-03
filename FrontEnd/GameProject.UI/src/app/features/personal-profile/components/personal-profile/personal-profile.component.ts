import {Component, OnInit} from '@angular/core';
import {Observable, of} from "rxjs";
import {User} from "../../../../shared/models/user";
import {AuthenticationService} from "../../../../core/authentication/services/authentication.service";
import {GameReviewerService} from "../../../../core/services/game-reviewer.service";

@Component({
  selector: 'app-personal-profile',
  templateUrl: './personal-profile.component.html',
  styleUrl: './personal-profile.component.scss'
})
export class PersonalProfileComponent implements OnInit{
  currentUser$: Observable<User | null> = of(null);
  private email: string;

  constructor(private authenticationService: AuthenticationService,
              private gameReviewerService: GameReviewerService) {
  }

  ngOnInit(): void {
    this.currentUser$ = this.authenticationService.currentUser$;
  }

  loadNextPageOfReviews(page: number){
    this.gameReviewerService.getGameReviewsForUser(page, 10)
      .subscribe({
        next: reviews => {
          this.currentUser$.subscribe({
            next: user => {
              user.gameReviews = reviews
              localStorage.setItem('user', JSON.stringify(user));
            }
          })
        }
      });
  }
}
