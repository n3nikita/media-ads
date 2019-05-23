import { Component, OnInit, Input, Output } from '@angular/core';
import { Category } from 'src/app/models/category';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {

  @Input() category: Category;
  @Output() categoryClick = new EventEmitter();

  constructor() { }

  ngOnInit() {
  }

  categoryClicked(categoryId){
    this.categoryClick.emit(categoryId);
  }

}
