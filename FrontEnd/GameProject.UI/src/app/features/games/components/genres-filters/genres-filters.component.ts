import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {GamingPlatform} from "../../../../shared/models/gaming-platform";
import {PlatformsResearcherService} from "../../../../core/services/platforms-researcher.service";
import {GenreMainInfo} from "../../../../shared/models/genre-main-info";
import {GenresResearcherService} from "../../../../core/services/genres-researcher.service";

@Component({
  selector: 'app-genres-filters',
  templateUrl: './genres-filters.component.html',
  styleUrl: './genres-filters.component.scss'
})
export class GenresFiltersComponent implements OnInit {
  genres: GenreMainInfo[] = [];
  @Output() chosenGenreEvent = new EventEmitter<number[]>();
  @Input() chosenGenreForFiltering: number[] = [];
  isAllGenres: boolean = false;

  constructor(private genresResearcher: GenresResearcherService) {
  }
  ngOnInit(): void {
    this.loadGenres();
  }

  loadGenres(){
    this.genresResearcher.getGenres()
      .subscribe({
        next: genres => {
          this.genres = genres;
        }
      })
  }

  addGenreForFiltering(genreId: number  ){
    if(this.chosenGenreForFiltering.includes(genreId)){
      this.chosenGenreForFiltering.splice(this.chosenGenreForFiltering.indexOf(genreId), 1);
    } else {
      this.chosenGenreForFiltering.push(genreId);
    }
    this.chosenGenreEvent.emit(this.chosenGenreForFiltering);
  }

  showAllGenres(){
    this.isAllGenres = !this.isAllGenres;
  }
}
