import { Component, OnInit } from '@angular/core';
import { ChannelsService } from 'src/app/services/channels.service';
import { Channel } from 'src/app/models/channel';
import { Category } from 'src/app/models/category';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  categories: Category[];

  constructor(private channelsService: ChannelsService) { }

  ngOnInit() {
    this.getCategories();
  }

  getCategories(){
    this.channelsService.getCategories().subscribe(data => this.categories = data);
  }

}
