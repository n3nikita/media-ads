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

  constructor(private titleService: Title, private chnnalesService: ChannelsService) { }

  ngOnInit() {
    this.titleService.setTitle('Home');
    this.getChannels();
  }

  getChannels(){
    this.chnnalesService.getChannels().subscribe(data => this.channels = data);
  }

  getChannelsByCategory(categoryId: number){
    console.log(categoryId);
  }

}
