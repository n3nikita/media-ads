import { Component, OnInit, Input } from '@angular/core';
import { Channel } from 'src/app/models/channel';

@Component({
  selector: 'app-channel',
  templateUrl: './channel.component.html',
  styleUrls: ['./channel.component.scss']
})
export class ChannelComponent implements OnInit {

  @Input() channel: Channel;

  constructor() { }

  ngOnInit() {
  }

}
