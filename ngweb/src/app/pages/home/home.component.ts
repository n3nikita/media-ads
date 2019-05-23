import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ChannelsService } from 'src/app/services/channels.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  channels;

  constructor(private titleService: Title, private channelsService: ChannelsService) { }

  ngOnInit() {
    this.titleService.setTitle('Channels');
    this.getChannels();
  }

  getChannels(){
    this.channelsService.getChannels().subscribe(data => this.channels = data);
  }

  getChannelsByCategory(categoryId: number){
    this.channelsService.getChannelsByCategory(categoryId).subscribe(data => this.channels = data);
  }

}
