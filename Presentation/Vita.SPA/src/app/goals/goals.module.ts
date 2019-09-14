import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GoalListComponent } from './goal-list/goal-list.component';
import { GoalListItemComponent } from './goal-list/goal-list-item/goal-list-item.component';

@NgModule({
  declarations: [GoalListComponent, GoalListItemComponent],
  imports: [
    CommonModule
  ],
  exports:[GoalListComponent]
})

export class GoalsModule { }
