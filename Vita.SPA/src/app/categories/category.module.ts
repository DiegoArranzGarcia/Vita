import { NgModule } from '@angular/core';
import { CategoryRoutingModule } from './category-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { CategoryService } from './category.service';

@NgModule({
  imports: [CommonModule, SharedModule, FontAwesomeModule, CategoryRoutingModule],
  providers: [CategoryService],
  declarations: [CategoryRoutingModule.components],
})
export class CategoryModule {}
