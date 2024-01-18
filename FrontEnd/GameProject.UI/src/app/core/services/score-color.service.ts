import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ScoreColorService {

  constructor() { }

  getColorBasedOnScore(score: number){
    switch (true){
      case score <= 39:
        return 'bg-red-700';
      case score <= 59:
        return 'bg-orange-700';
      case score <= 79:
        return 'bg-yellow-700';
      case score <= 89:
        return 'bg-green-700';
      case score <= 100:
        return 'bg-green-900';
      default:
        return '';
    }
  }
}
