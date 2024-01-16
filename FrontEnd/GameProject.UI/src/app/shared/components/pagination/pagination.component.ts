import {Component, EventEmitter, Input, Output} from '@angular/core';

@Component({
  selector: 'app-pagination',
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.scss'
})
export class PaginationComponent {
  @Input({required: true}) totalItemsCount: number;
  @Input({required: true}) itemsPerPage: number;
  @Input({required: true}) currentPage: number;
  @Output() pageChanged: EventEmitter<number> = new EventEmitter<number>();
  protected readonly Math = Math;

  nextPage(pageNumber: number){
    this.pageChanged.emit(pageNumber);
  }
}
