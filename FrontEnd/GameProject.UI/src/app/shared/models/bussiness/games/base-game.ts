import {GameAllInfo} from "../../rawg-api/games/game-all-info";

export interface BaseGame{
  game: GameAllInfo;
  name: string;
  backgroundImage: string;
  rawgId: number;
  platform: string;
}
