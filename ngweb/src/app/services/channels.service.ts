import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Channel } from '../models/channel';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class ChannelsService {

  private url: string = "http://localhost:63472/api/channels/";

  constructor(private http: HttpClient) { }

  getChannels(): Observable<Channel[]> {
    return this.http.get<Channel[]>(this.url);
  }

  getCategories(): Observable<Category[]>{
    return this.http.get<Category[]>(this.url + 'categories');
  }

  getChannelsByCategory(id: number): Observable<Channel[]>{
    return this.http.get<Channel[]>(this.url + 'category/' + id);
  }

  getChannelByLink(link: string): Observable<Channel>{
    return this.http.get<Channel>(this.url + 'link/' + link);
  }
}
