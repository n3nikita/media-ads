import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { ChannelsService } from 'src/app/services/channels.service';
import { Channel } from 'src/app/models/channel';
import { TouchSequence } from 'selenium-webdriver';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  channels;
  empty: boolean = false;

  constructor(private titleService: Title, private channelsService: ChannelsService) { }

  ngOnInit() {
    this.titleService.setTitle('Все каналы | Media Ads');
    this.getChannels();
  }

  getChannels(){
    this.channelsService.getChannels().subscribe(data => this.addChannels(data));
  }

  getChannelsByCategory(categoryId: number){
    if(categoryId === 0) {
      this.getChannels();
    } else {
      this.channelsService.getChannelsByCategory(categoryId).subscribe(data => this.addChannels(data));
    }
  }

  addChannels(data: Channel[]){
    this.channels = data;
    if(data.length){
      this.empty = false;
    } else {
      this.empty = true;
    }
  }

}
