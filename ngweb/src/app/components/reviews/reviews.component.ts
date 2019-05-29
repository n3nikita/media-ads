import { Component, OnInit, Input } from '@angular/core';
import { ReviewsService } from 'src/app/services/reviews.service';
import { Review } from 'src/app/models/review';
import { AuthService } from 'src/app/services/auth.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent implements OnInit {

  @Input() channelLink: string;
  reviews: Review[];

  reviewForm = new FormGroup({
    text: new FormControl(''),
    rating: new FormControl('')
  });

  constructor(private reviewService: ReviewsService, private authService: AuthService) { }

  get isLoggedIn(): boolean {
    return this.authService.isLoggedIn;
  }

  ngOnInit() {
    this.reviewService.getReviewsByChannelLink(this.channelLink)
      .subscribe(data => this.reviews = data);
  }

  create(){
    let review = { text: this.reviewForm.get('text').value, rating: this.reviewForm.get('rating').value, channelId: 1, userId: 1, date: new Date() } as Review;
    this.reviewService.createReview(review).subscribe(result => console.log(result));
  }

}
