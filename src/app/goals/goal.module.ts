import { NgModule } from '@angular/core';
import { GoalRoutingModule } from './goal-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { GoalService } from './goal.service';

@NgModule({
  imports: [CommonModule, SharedModule, FontAwesomeModule, GoalRoutingModule],
  providers: [GoalService],
  declarations: [GoalRoutingModule.components],
})
export class GoalModule {}
