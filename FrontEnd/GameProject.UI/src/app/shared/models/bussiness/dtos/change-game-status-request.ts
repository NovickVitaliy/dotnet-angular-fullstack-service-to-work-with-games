import {GameStatus} from "../../game-status";
import {GameAllInfo} from "../../rawg-api/games/game-all-info";

export interface ChangeGameStatusRequest {
  oldStatus: GameStatus;
  newStatus: GameStatus;
  game: GameAllInfo;
  gameRawgId: number;
  platform: string;
}
