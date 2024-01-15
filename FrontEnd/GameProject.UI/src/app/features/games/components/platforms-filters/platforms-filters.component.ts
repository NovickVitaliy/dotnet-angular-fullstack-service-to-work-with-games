import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {GamingPlatform} from "../../../../shared/models/gaming-platform";
import {PlatformsResearcherService} from "../../../../core/services/platforms-researcher.service";

@Component({
  selector: 'app-platforms-filters',
  templateUrl: './platforms-filters.component.html',
  styleUrl: './platforms-filters.component.scss'
})
export class PlatformsFiltersComponent implements OnInit {
  gamingPlatforms: GamingPlatform[] = [];
  @Output() chosenPlatformEvent = new EventEmitter<number[]>();
  @Input() chosenPlatformsForFiltering: number[] = [];
  isAllPlatforms: boolean = false;

  constructor(private platformsResearcher: PlatformsResearcherService) {
  }
  ngOnInit(): void {
    this.loadPlatforms();
  }

  loadPlatforms(){
    this.platformsResearcher.getAllPlatforms()
      .subscribe({
        next: platforms => {
          this.gamingPlatforms = platforms;
        }
      })
  }

  addPlatformForFiltering(platformId: number  ){
    if(this.chosenPlatformsForFiltering.includes(platformId)){
      this.chosenPlatformsForFiltering.splice(this.chosenPlatformsForFiltering.indexOf(platformId), 1);
    } else {
      this.chosenPlatformsForFiltering.push(platformId);
    }
    console.log(this.chosenPlatformsForFiltering);
    this.chosenPlatformEvent.emit(this.chosenPlatformsForFiltering);
  }

  showAllPlatforms(){
    this.isAllPlatforms = !this.isAllPlatforms;
  }
}
