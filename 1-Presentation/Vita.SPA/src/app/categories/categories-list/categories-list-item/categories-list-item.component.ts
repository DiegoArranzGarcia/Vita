import { Component, OnInit, Input } from '@angular/core';
import { Category } from '../../category.model';

@Component({
  selector: 'categories-list-item',
  templateUrl: './categories-list-item.component.html'
})
export class CategoriesListItemComponent implements OnInit {

  @Input() category: Category;

  constructor() { }

  ngOnInit() {
  }

}
