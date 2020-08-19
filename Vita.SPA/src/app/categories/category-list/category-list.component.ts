import { Component, OnInit } from '@angular/core';
import { Category } from '../category.model';
import { CategoryService } from '../category.service';

@Component({
  selector: 'vita-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.sass'],
})
export class CategoryListComponent implements OnInit {
  categories: Category[];

  constructor(private categoryService: CategoryService) {}

  ngOnInit() {
    this.categoryService.getCategories().subscribe((x) => (this.categories = x));
  }
}
