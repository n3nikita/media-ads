import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ChannelsService } from 'src/app/services/channels.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.scss']
})
export class DetailsComponent implements OnInit {

  channelLink;
  channel;

  constructor(private route: ActivatedRoute, private channelService: ChannelsService) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.channelLink = params['link'];
      this.channelService.getChannelByLink(this.channelLink).subscribe(data => this.channel = data);
    })
  }

}
