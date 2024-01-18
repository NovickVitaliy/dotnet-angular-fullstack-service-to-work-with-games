import {Expose} from "class-transformer";
import {GameVideo} from "./game-video";

export class GameTrailer{
  id: number;

  @Expose({name: 'data'})
  videos: GameVideo[];
}
