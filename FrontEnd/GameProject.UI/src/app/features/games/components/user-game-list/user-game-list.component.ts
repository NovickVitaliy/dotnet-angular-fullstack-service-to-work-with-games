import {Component, OnInit} from '@angular/core';
import {AuthenticationService} from "../../../../core/authentication/services/authentication.service";
import {map, Observable} from "rxjs";
import {User} from "../../../../shared/models/user";
import {GameStatus, GameStatusToLabelMapping} from "../../../../shared/models/game-status";

@Component({
  selector: 'app-user-game-list',
  templateUrl: './user-game-list.component.html',
  styleUrl: './user-game-list.component.scss'
})
export class UserGameListComponent implements OnInit {
  currentUser$: Observable<User>;
  public GameStatusToLabelMapping = GameStatusToLabelMapping;
  public gameStatuses = Object.values(GameStatus);

  constructor(private authenticationService: AuthenticationService) {
  }

  ngOnInit(): void {
    this.currentUser$ = this.authenticationService.currentUser$;

  }

  showChange(event: any){
    console.log(event.target.value)
  }

  protected readonly GameStatus = GameStatus;
}
