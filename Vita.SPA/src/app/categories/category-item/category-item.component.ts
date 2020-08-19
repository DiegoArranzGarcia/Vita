import { Component, OnInit, Input } from '@angular/core';
import { Category } from '../category.model';
import { faCircle } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'vita-category-item',
  templateUrl: './category-item.component.html',
  styleUrls: ['./category-item.component.sass'],
})
export class CategoryItemComponent implements OnInit {
  @Input() category: Category;
  categoryListIcon = faCircle;

  constructor() {}

  ngOnInit() {}
}
