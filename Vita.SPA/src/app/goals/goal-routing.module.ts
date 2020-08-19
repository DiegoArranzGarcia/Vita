import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GoalHomeComponent } from './goal-home/goal-home.component';
import { GoalCardListComponent } from './goal-card-list/goal-card-list.component';
import { GoalCardComponent } from './goal-card/goal-card.component';
import { CreateGoalCardComponent } from './create-goal-card/create-goal-card.component';

const routes: Routes = [{ path: '', component: GoalHomeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GoalRoutingModule {
  static components = [GoalHomeComponent, GoalCardListComponent, GoalCardComponent, CreateGoalCardComponent];
}
