import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersCategoriesListComponent } from './users-categories-list/users-categories-list.component';
import { UsersCategoriesListItemComponent } from './users-categories-list/users-categories-list-item/users-categories-list-item.component';
import { UsersCategoriesService } from './users-categories.service';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    UsersCategoriesListComponent, 
    UsersCategoriesListItemComponent,
  ],  
  imports: [
    CommonModule,
    SharedModule
  ],
  exports: [
    UsersCategoriesListComponent,
  ],
  providers: [
    UsersCategoriesService
  ]
})
export class UsersCategoriesModule { }
