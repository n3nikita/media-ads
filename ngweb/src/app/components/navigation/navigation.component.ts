import { Component, OnInit, Output } from '@angular/core';
import { ChannelsService } from 'src/app/services/channels.service';
import { Channel } from 'src/app/models/channel';
import { Category } from 'src/app/models/category';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent implements OnInit {

  @Output() categoryClick = new EventEmitter();
  categories: Category[] = [{id: 0, name: 'Все'} as Category];
  

  constructor(private channelsService: ChannelsService) { }

  ngOnInit() {
    this.getCategories();
  }

  getCategories(){
    this.channelsService.getCategories().subscribe(data => this.categories.push(...data));
  }

  getChannelsByCategory(categoryId){
    this.categoryClick.emit(categoryId)
  }

}
