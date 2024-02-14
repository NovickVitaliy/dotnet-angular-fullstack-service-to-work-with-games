import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {PublishNewsRequest} from "../../shared/models/admin/publish-news-request";
import {environment} from "../../../environments/environment.development";

@Injectable({
  providedIn: 'root'
})
export class AdminNewsService {

  constructor(private http: HttpClient) { }

  publishNews(publishNewsRequest: PublishNewsRequest){
    return this.http.post(`${environment.apiUrl}admin-news`, publishNewsRequest);
  }
}
