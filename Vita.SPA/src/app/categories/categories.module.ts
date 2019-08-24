import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoriesListComponent } from './categories-list/categories-list.component';
import { CategoriesListItemComponent } from './categories-list/categories-list-item/categories-list-item.component';
import { CategoryService } from './category.service';

@NgModule({
  declarations: [
    CategoriesListComponent, 
    CategoriesListItemComponent,
  ],  
  imports: [
    CommonModule
  ],
  exports: [
    CategoriesListComponent
  ],
  providers: [
    CategoryService
  ]
})
export class CategoriesModule { }
