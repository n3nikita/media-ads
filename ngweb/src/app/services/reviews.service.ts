import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Review } from '../models/review';

@Injectable({
  providedIn: 'root'
})
export class ReviewsService {

  private url: string = "http://localhost:63472/api/review/";

  constructor(private http: HttpClient) { }

  getReviews(): Observable<Review[]>{
    return this.http.get<Review[]>(this.url);
  }

  getReviewsByChannelId(id: number): Observable<Review[]>{
    return this.http.get<Review[]>(this.url + 'channel/' + id);
  }

  getReviewsByChannelLink(link: string): Observable<Review[]>{
    return this.http.get<Review[]>(this.url + 'channel/' + link);
  }

  getReviewsByUser(id: number): Observable<Review[]>{
    return this.http.get<Review[]>(this.url + 'user/' + id);
  }

  getAerageRating(id: number): Observable<number> {
    return this.http.get<number>(this.url + 'rating/' + id);
  }

  createReview(review: Review) {
    return this.http.post(this.url, review);
  }
}
