import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {GameReview} from "../../shared/models/bussiness/game-reviews/game-review";
import {environment} from "../../../environments/environment.development";
import {PagedResult} from "../../shared/models/shared/paged-result";
import {GetGameReviewsRequest} from "../../shared/models/dtos/bussiness/game-review/get-game-reviews-request";
import {CreateGameReviewRequest} from "../../shared/models/dtos/bussiness/game-review/create-game-review-request";
import {UpdateGameReviewRequest} from "../../shared/models/dtos/bussiness/game-review/update-game-review-request";
import {DeleteGameReviewRequest} from "../../shared/models/dtos/bussiness/game-review/delete-game-review-request";

@Injectable({
  providedIn: 'root'
})
export class GameReviewerService {
  constructor(private http: HttpClient) {
  }

  getReviewsForGame(getGameReviewsRequest: GetGameReviewsRequest) {

    return this.http.get<PagedResult<GameReview>>(`${environment.apiUrl}GameReviews/GetReviewsForGame`,
      {
        params: {
          gameRawgId: getGameReviewsRequest.gameRawgId,
          itemsPerPage: getGameReviewsRequest.itemsPerPage,
          page: getGameReviewsRequest.page
        }
      });
  }

  createGameReview(createGameReviewRequest: CreateGameReviewRequest) {
    return this.http.post<GameReview>(`${environment.apiUrl}GameReviews/CreateGameReview`, createGameReviewRequest);
  }

  updateGameReview(updateGameReviewRequest: UpdateGameReviewRequest) {
    return this.http.put<GameReview>(`${environment.apiUrl}GameReviews/UpdateGameReview`, updateGameReviewRequest);
  }

  deleteGameReview(deleteGameReviewRequest: DeleteGameReviewRequest){
    return this.http.delete(`${environment.apiUrl}GameReviews/DeleteGameReview?reviewId=${deleteGameReviewRequest.reviewId}`)
  }
}
