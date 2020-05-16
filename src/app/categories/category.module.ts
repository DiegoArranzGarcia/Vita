import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CategoryListComponent } from './category-list/category-list.component';
import { CategoryListItemComponent } from './category-list/item/category-list-item.component';
import { CategoryService } from './category.service';
import { SharedModule } from '../shared/shared.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

@NgModule({
  declarations: [
    CategoryListComponent, 
    CategoryListItemComponent,
  ],  
  imports: [
    CommonModule,
    SharedModule,
    FontAwesomeModule
  ],
  exports: [
    CategoryListComponent,
  ],
  providers: [
    CategoryService
  ]
})
export class CategoryModule { }
