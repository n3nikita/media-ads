import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Channel } from '../models/channel';

@Injectable({
  providedIn: 'root'
})
export class ChannelsService {

  private url: string = "http://localhost:63472/api/channels";

  constructor(private http: HttpClient) { }

  getChannels(): Observable<Channel[]> {
    return this.http.get<Channel[]>(this.url);
  }
}
