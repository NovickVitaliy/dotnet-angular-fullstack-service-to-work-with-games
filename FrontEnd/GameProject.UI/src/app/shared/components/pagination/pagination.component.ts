import {Component, EventEmitter, Input, Output, SimpleChanges} from '@angular/core';

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
  get totalPages(): number {
    let value = Math.ceil(this.totalItemsCount / this.itemsPerPage);
    console.log(value);
    return value;
  }

  selectPageNumber(pageNumber: number) {
    this.currentPage = pageNumber;
    this.pageChanged.emit(this.currentPage);
  }

  getPagesArray(): number[] {
    const totalPages = this.totalPages;
    const startPage = Math.max(1, this.currentPage - Math.floor(5 / 2));
    const endPage = Math.min(this.totalPages, startPage + 5 - 1);

    return Array.from({ length: endPage - startPage + 1 }, (_, i) => i + startPage);
  }
}
