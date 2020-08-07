import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoryHomeComponent } from './category-home.component';
import { CategoryListComponent } from './category-list/category-list.component';
import { CategoryListItemComponent } from './category-list/item/category-list-item.component';

const routes: Routes = [{ path: '', component: CategoryHomeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CategoryRoutingModule {
  static components = [CategoryHomeComponent, CategoryListComponent, CategoryListItemComponent];
}
