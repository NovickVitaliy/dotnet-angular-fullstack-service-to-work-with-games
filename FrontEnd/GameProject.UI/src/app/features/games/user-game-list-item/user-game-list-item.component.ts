import {Component, Input, OnInit} from '@angular/core';
import {BaseGame} from "../../../shared/models/bussiness/games/base-game";
import {GameStatus, GameStatusToLabelMapping} from "../../../shared/models/game-status";
import {AuthenticationService} from "../../../core/authentication/services/authentication.service";
import {UserGameListService} from "../../../core/services/user-game-list.service";
import {take} from "rxjs";
import {User} from "../../../shared/models/user";

@Component({
  selector: 'app-user-game-list-item',
  templateUrl: './user-game-list-item.component.html',
  styleUrl: './user-game-list-item.component.scss'
})
export class UserGameListItemComponent implements OnInit {
  @Input({required: true}) game: BaseGame;
  @Input({required: true}) status: GameStatus;
  protected readonly GameStatusToLabelMapping = GameStatusToLabelMapping;
  public gameStatuses = Object.values(GameStatus);
  newStatus: GameStatus;
  protected readonly GameStatus = GameStatus;

  constructor(private authenticationService: AuthenticationService,
              private userGameListService: UserGameListService) {
  }

  ngOnInit(): void {
    this.newStatus = this.status;
  }

  setNewStatus(event: any) {
    this.newStatus = event.target.value;
  }

  removeGameFromList() {
    this.userGameListService.removeGameFromUserList({gameToRemoveRawgId: this.game.rawgId, status: this.status})
      .subscribe({
        next: _ => {
          this.authenticationService.currentUser$.pipe(take(1))
            .subscribe({
              next: user => {
                this.removeGame(user);
                this.authenticationService.setCurrentUser(user);
              }
            });
        }
      })
  }

  changeGameStatus() {
    this.userGameListService.changeGameStatusInUserList(
      {
        game: {
          platforms: [],
          name: this.game.name,
          background_image: this.game.backgroundImage,
          id: this.game.rawgId,
          description_raw: "",
          tags: [],
          metacritic: 0,
          genres: [],
          released: null,
          developers: [],
          metacritic_url: "",
          publishers: []
        },
        gameRawgId: this.game.rawgId,
        newStatus: this.newStatus,
        platform: this.game.platform,
        oldStatus: this.status
      })
      .subscribe({
        next: _ => {
          this.authenticationService.currentUser$.pipe(take(1))
            .subscribe({
              next: user => {
                this.removeGame(user);
                this.addToList(user);
                this.authenticationService.setCurrentUser(user);
              }
            });
        }
      })
  }

  private removeGame(user: User) {
    switch (true) {
      case GameStatus.Started === this.status:
        user.startedGames.splice(user.startedGames.indexOf(this.game), 1);
        break;
      case GameStatus.InProgress === this.status:
        user.inProgressGames.splice(user.inProgressGames.indexOf(this.game), 1);
        break;
      case GameStatus.Finished === this.status:
        user.finishedGames.splice(user.finishedGames.indexOf(this.game), 1);
        break;
      case GameStatus.Abandoned === this.status:
        user.abandonedGames.splice(user.abandonedGames.indexOf(this.game), 1);
        break;
      case GameStatus.Desired === this.status:
        user.desiredGames.splice(user.desiredGames.indexOf(this.game), 1);
        break;
    }
  }

  private addToList(user: User){

    switch (this.newStatus) {
      case GameStatus.Started:
        user.startedGames.push(this.game);
        break;
      case GameStatus.InProgress:
        user.inProgressGames.push(this.game);
        break;
      case GameStatus.Finished:
        user.finishedGames.push(this.game);
        break;
      case GameStatus.Abandoned:
        user.abandonedGames.push(this.game);
        break;
      case GameStatus.Desired:
        user.desiredGames.push(this.game);
        break;
    }
  }
}
