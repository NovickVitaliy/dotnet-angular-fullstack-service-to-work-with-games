export interface GameReview{
  reviewId: string;
  authorName: string;
  authorEmail: string;
  authorProfilePhotoUrl?: string;
  review: string;
  score: number;
  dateWritten: Date;
  gameName: string;
}
