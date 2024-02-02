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
  @Input({required: true}) collectionSize = 0;
  @Output() pageChanged: EventEmitter<number> = new EventEmitter<number>();
  protected readonly Math = Math;

  nextPage(pageNumber: number){
    this.pageChanged.emit(pageNumber);
  }

  /** The number of buttons to show either side of the current page */
  @Input()
  maxSize = 2;

  /** Display the First/Last buttons */
  @Input()
  firstLastButtons = false;

  /** Display the Next/Previous buttons */
  @Input()
  nextPreviousButtons = true;

  /** Display small pagination buttons */
  @Input()
  small = false;

  totalPages: any[] = [];

  constructor() {}

  ngOnInit(): void {
    this.totalPages = new Array(Math.ceil(this.collectionSize / this.itemsPerPage));
  }

  /** Update totalPage number if the collectionSize or pageSize values change */
  ngOnChanges(changes: SimpleChanges) {
    this.totalPages = new Array(Math.ceil(this.collectionSize / this.itemsPerPage));
  }

  /** Set page number */
  selectPageNumber(pageNumber: number) {
    this.currentPage = pageNumber;
    this.pageChanged.emit(this.currentPage);
  }

  /** Set next page number */
  next() {
    const nextPage = this.currentPage + 1;
    nextPage <= this.totalPages.length && this.selectPageNumber(nextPage);
  }

  /** Set previous page number */
  previous() {
    const previousPage = this.currentPage - 1;
    previousPage >= 1 && this.selectPageNumber(previousPage);
  }
}
