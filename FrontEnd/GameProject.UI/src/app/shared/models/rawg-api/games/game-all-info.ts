import {PlatformInfo} from "../platforms/platform-info";
import {GameDeveloper} from "../developers/game-developer";
import {GenreMainInfo} from "../genres/genre-main-info";
import {GameTag} from "../tags/game-tag";
import {GamePublisher} from "../publishers/game-publisher";
import {GameReview} from "../../bussiness/game-reviews/game-review";

export interface GameAllInfo{
  id: number;
  name: string;
  description_raw: string;
  metacritic: number;
  released: Date;
  background_image: string;
  metacritic_url: string;
  platforms: PlatformInfo[];
  developers: GameDeveloper[];
  genres: GenreMainInfo[];
  tags: GameTag[];
  publishers: GamePublisher[];
}
