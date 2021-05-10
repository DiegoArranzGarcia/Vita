import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GoalHomeComponent } from './goal-home/goal-home.component';
import { GoalCardListComponent } from './goal-card-list/goal-card-list.component';
import { GoalCardComponent } from './goal-card/goal-card.component';
import { CreateGoalCardComponent } from './create-goal-card/create-goal-card.component';
import { GoalCardMenuComponent } from './goal-card-menu/goal-card-menu.component';
import { GoalStatusComponent } from './goal-status/goal-status.component';
import { GoalCardAimDateComponent } from './goal-card-aim-date/goal-card-aim-date.component';
import { GoalAimDatePipe } from './goal-card-aim-date/goal-aim-date-pipe/aim-date.pipe';

const routes: Routes = [{ path: '', component: GoalHomeComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GoalRoutingModule {
  static components = [
    GoalHomeComponent,
    CreateGoalCardComponent,
    GoalCardListComponent,
    GoalCardComponent,
    GoalCardMenuComponent,
    GoalStatusComponent,
    GoalCardAimDateComponent,
    GoalAimDatePipe,
  ];
}
