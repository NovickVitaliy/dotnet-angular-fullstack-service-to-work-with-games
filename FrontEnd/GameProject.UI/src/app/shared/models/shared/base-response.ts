export interface BaseResponse<T> {
  description: string;
  data?: T;
}
