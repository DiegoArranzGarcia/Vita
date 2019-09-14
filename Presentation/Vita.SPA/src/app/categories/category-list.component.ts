import { Component, OnInit } from '@angular/core';
import { Category } from './category.model';
import { CategoryService } from './category.service';

@Component({
  selector: 'category-list',
  templateUrl: './category-list.component.html'
})

export class CategoryListComponent implements OnInit {

  categories: Category[];

  constructor(private categoryService : CategoryService) { }

  ngOnInit() {
    this.categoryService.getAllCategoriesOfUser(1).subscribe(x => this.categories = x);
  }

}
