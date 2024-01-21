import {Component, ElementRef, Input, OnInit, ViewChild} from '@angular/core';
import {GameAllInfo} from "../../../../shared/models/rawg-api/games/game-all-info";
import {GameStatus, GameStatusToLabelMapping} from "../../../../shared/models/game-status";
import {User} from "../../../../shared/models/user";
import {UserGameListService} from "../../../../core/services/user-game-list.service";
import {Observable, take} from "rxjs";
import {ToastrService} from "ngx-toastr";
import {AuthenticationService} from "../../../../core/authentication/services/authentication.service";
import {BaseGame} from "../../../../shared/models/bussiness/games/base-game";

@Component({
  selector: 'app-list-modal',
  templateUrl: './list-modal.component.html',
  styleUrl: './list-modal.component.scss'
})
export class ListModalComponent implements OnInit {
  @ViewChild('closeModalButton') closeModalButton: ElementRef;
  @Input({required: true}) game: GameAllInfo | null = null;
  public GameStatusToLabelMapping = GameStatusToLabelMapping;
  public gameStatuses = Object.values(GameStatus);
  @Input({required: true}) currentUser$: Observable<User>;
  chosenStatus: GameStatus;
  chosenPlatform: string;

  constructor(private gameUserListService: UserGameListService,
              private toastrService: ToastrService,
              private authenticationService: AuthenticationService) {
  }

  ngOnInit(): void {
    this.chosenStatus = this.gameStatuses[0];
    this.chosenPlatform = this.game.platforms[0].platform.name;
    console.log(`Platform: ${this.chosenPlatform}; Status: ${this.chosenStatus}`)
  }


  addToList() {
    this.gameUserListService.addGameToUserList({
      status: this.chosenStatus,
      game: this.game,
      platform: this.chosenPlatform
    })
      .subscribe({
        next: _ => {
          this.currentUser$.pipe(take(1))
            .subscribe({
              next: user => {
                const gameToAdd: BaseGame = {
                  rawgId: this.game.id,
                  name: this.game.name,
                  backgroundImage: this.game.background_image,
                  platform: this.chosenPlatform,
                  game: this.game
                };
                switch (this.chosenStatus) {
                  case GameStatus.Started:
                    user.startedGames.push(gameToAdd);
                    break;
                  case GameStatus.InProgress:
                    user.inProgressGames.push(gameToAdd);
                    break;
                  case GameStatus.Finished:
                    user.finishedGames.push(gameToAdd);
                    break;
                  case GameStatus.Abandoned:
                    user.abandonedGames.push(gameToAdd);
                    break;
                  case GameStatus.Desired:
                    user.desiredGames.push(gameToAdd);
                    break;
                }
                this.authenticationService.setCurrentUser(user);
                return false;
              }
            })
          this.toastrService.success("Game has been successfully added to the list!");
          this.closeModalButton.nativeElement.click();
        }
      });
  }

  doesUserHaveThisGameInSomeList(status: string): boolean {
    this.currentUser$.pipe(take(1))
      .subscribe({
        next: user => {
          switch (status) {
            case GameStatus.Started:
              return user.startedGames.some(e => e.rawgId === this.game.id);
            case GameStatus.InProgress:
              return user.inProgressGames.some(e => e.rawgId === this.game.id);
            case GameStatus.Finished:
              return user.finishedGames.some(e => e.rawgId === this.game.id);
            case GameStatus.Abandoned:
              return user.abandonedGames.some(e => e.rawgId === this.game.id);
            case GameStatus.Desired:
              return user.desiredGames.some(e => e.rawgId === this.game.id);
          }
          return false;
        }
      })
    return false;
  }

  setChosenStatus(status: string) {
    console.log(status);
    this.chosenStatus = status as GameStatus;
    console.log(this.chosenStatus);
  }

  setChosenPlatform(platform: string) {
    this.chosenPlatform = platform;
  }
}
