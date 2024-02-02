import {Component, Input} from '@angular/core';
import {GameStore} from "../../../../shared/models/rawg-api/game-stores/game-store";

@Component({
  selector: 'app-game-stores-modal',
  templateUrl: './game-stores-modal.component.html',
  styleUrl: './game-stores-modal.component.scss'
})
export class GameStoresModalComponent {
  @Input({required: true}) gameStores: GameStore[];
}
