import { Component, OnInit, Input } from '@angular/core';
import { ReviewsService } from 'src/app/services/reviews.service';
import { Review } from 'src/app/models/review';
import { AuthService } from 'src/app/services/auth.service';
import { FormGroup, FormControl } from '@angular/forms';
import { Channel } from 'src/app/models/channel';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent implements OnInit {

  @Input() channel: Channel;
  user: User;
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
    this.reviewService.getReviewsByChannelLink(this.channel.link)
      .subscribe(data => this.reviews = data);
    this.user = this.authService.getUserInfo();
  }

  create(){
    let review : Review = { text: this.reviewForm.get('text').value, rating: this.reviewForm.get('rating').value, channelId: this.channel.id, userId: this.user.id, date: new Date() };
    this.reviewService.createReview(review).subscribe(result => {
      this.reviews.push(result); 
      this.reviewForm.reset();
    });
  }

}
