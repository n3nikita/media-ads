import { Component, OnInit, Input } from '@angular/core';
import { ReviewsService } from 'src/app/services/reviews.service';
import { Review } from 'src/app/models/review';

@Component({
  selector: 'app-reviews',
  templateUrl: './reviews.component.html',
  styleUrls: ['./reviews.component.scss']
})
export class ReviewsComponent implements OnInit {

  @Input() channelLink: string;
  reviews: Review[];

  constructor(private reviewService: ReviewsService) { }

  ngOnInit() {
    this.reviewService.getReviewsByChannelLink(this.channelLink)
      .subscribe(data => this.reviews = data);
  }

}
