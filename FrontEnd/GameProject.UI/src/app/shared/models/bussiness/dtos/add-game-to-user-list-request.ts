import {GameAllInfo} from "../../rawg-api/games/game-all-info";
import {GameStatus} from "../../game-status";

export interface AddGameToUserListRequest{
  game: GameAllInfo;
  status: GameStatus;
  platform: string;
}
