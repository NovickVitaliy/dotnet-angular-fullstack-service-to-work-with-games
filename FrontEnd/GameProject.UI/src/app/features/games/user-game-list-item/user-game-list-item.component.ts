import {Component, Input, OnInit} from '@angular/core';
import {BaseGame} from "../../../shared/models/bussiness/games/base-game";
import {GameStatus, GameStatusToLabelMapping} from "../../../shared/models/game-status";

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

  ngOnInit(): void {
    this.newStatus = this.status;
  }

  setNewStatus(event: any) {
    this.newStatus = event.target.value;
  }
}
