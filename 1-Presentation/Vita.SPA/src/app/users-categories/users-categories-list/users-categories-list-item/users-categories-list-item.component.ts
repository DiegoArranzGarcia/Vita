import { Component, OnInit, Input } from '@angular/core';
import { UserCategory } from '../../user-category.model';

@Component({
  selector: 'users-categories-list-item',
  templateUrl: './users-categories-list-item.component.html'
})
export class UsersCategoriesListItemComponent implements OnInit {

  @Input() userCategory: UserCategory;

  constructor() { }

  ngOnInit() {
  }

}
