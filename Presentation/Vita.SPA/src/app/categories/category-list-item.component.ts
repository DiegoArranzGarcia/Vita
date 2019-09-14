import { Component, OnInit, Input } from '@angular/core';
import { Category } from './category.model';

@Component({
  selector: 'category-list-item',
  templateUrl: './category-list-item.component.html'
})

export class CategoryListItemComponent implements OnInit {

  @Input() category: Category;

  constructor() { }

  ngOnInit() {
  }

}