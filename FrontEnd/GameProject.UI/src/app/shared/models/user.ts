import {StartedGame} from "./bussiness/games/started-game";
import {InProgressGame} from "./bussiness/games/in-progress-game";
import {FinishedGame} from "./bussiness/games/finished-game";
import {AbandonedGame} from "./bussiness/games/abandoned-game";
import {DesiredGame} from "./bussiness/games/desired-game";
import {GameReview} from "./bussiness/game-reviews/game-review";

export interface User {
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  accessToken: string;
  refreshToken: string;
  platforms: string[];
  description: string;
  location: string;
  profilePhotoUrl?: string;
  daysWithUs: number;
  startedGames: StartedGame[];
  inProgressGames: InProgressGame[];
  finishedGames: FinishedGame[];
  abandonedGames: AbandonedGame[];
  desiredGames: DesiredGame[];
  gameReviews: GameReview[];
}
