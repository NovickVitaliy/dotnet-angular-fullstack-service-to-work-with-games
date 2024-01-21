import {GameStatus} from "../../game-status";

export interface RemoveGameFromUserListRequest{
  gameToRemoveRawgId: number;
  status: GameStatus;
}
