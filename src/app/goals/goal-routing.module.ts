import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GoalHomeComponent } from './goal-home/goal-home.component';
import { GoalListComponent } from './goal-list/goal-list.component';
import { GoalItemComponent } from './goal-item/goal-item.component';

const routes: Routes = [{ path: '', component: GoalHomeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GoalRoutingModule {
  static components = [GoalHomeComponent, GoalListComponent, GoalItemComponent];
}
