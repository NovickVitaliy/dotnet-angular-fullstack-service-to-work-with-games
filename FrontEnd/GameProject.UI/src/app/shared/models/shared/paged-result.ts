export interface PagedResult<T> {
  totalCount: number;
  currentPage: number;
  itemsPerPage: number;
  items: T[];
}
