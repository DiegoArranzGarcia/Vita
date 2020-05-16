import { Component, OnInit, Input } from '@angular/core';
import { Category } from '../../category.model';
import { faCircle  } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'category-list-item',
  templateUrl: './category-list-item.component.html',
  styleUrls: ['./category-list-item.component.sass']
})

export class CategoryListItemComponent implements OnInit {

  @Input() category: Category;
  categoryListIcon = faCircle;

  constructor() { }

  ngOnInit() {
  }

}