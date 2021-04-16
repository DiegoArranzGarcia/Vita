import { NgModule } from '@angular/core';
import { GoalRoutingModule } from './goal-routing.module';
import { SharedModule } from '../shared/shared.module';
import { GoalService } from './goal.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TabViewModule } from 'primeng/tabview';
import { CalendarModule } from 'primeng/calendar';

@NgModule({
  imports: [SharedModule, GoalRoutingModule, FormsModule, ReactiveFormsModule, TabViewModule, CalendarModule],
  providers: [GoalService],
  declarations: [GoalRoutingModule.components],
})
export class GoalModule {}
