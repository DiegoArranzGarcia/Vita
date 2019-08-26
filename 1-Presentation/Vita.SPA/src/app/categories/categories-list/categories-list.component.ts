import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../category.service';
import { Category } from '../category.model';

@Component({
  selector: 'categories-list',
  templateUrl: './categories-list.component.html'
})
export class CategoriesListComponent implements OnInit {

  categories: Category[];

  constructor(private _categoryService : CategoryService) { }

  ngOnInit() {
    this._categoryService.getAllCategories().subscribe(x => this.categories = x);
  }

}
