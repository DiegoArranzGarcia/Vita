import { Component, OnInit } from '@angular/core';
import { UserCategory } from '../user-category.model';
import { UsersCategoriesService } from '../users-categories.service';

@Component({
  selector: 'users-categories-list',
  templateUrl: './users-categories-list.component.html'
})

export class UsersCategoriesListComponent implements OnInit {

  userCategories: UserCategory[];

  constructor(private _userCategoryService : UsersCategoriesService) { }

  ngOnInit() {
    this._userCategoryService.getAllUserCategories(1).subscribe(x => this.userCategories = x);
  }

}
