import { NgModule } from '@angular/core';
import { GoalRoutingModule } from './goal-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { GoalService } from './goal.service';
import { NgxPrettyDateModule } from 'ngx-pretty-date';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [CommonModule, SharedModule, FontAwesomeModule, GoalRoutingModule, NgxPrettyDateModule, FormsModule, ReactiveFormsModule],
  providers: [GoalService],
  declarations: [GoalRoutingModule.components],
})
export class GoalModule {}
