import { NgModule } from '@angular/core';
import { GoalRoutingModule } from './goal-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CommonModule } from '@angular/common';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { GoalService } from './goal.service';
import { NgxPrettyDateModule } from 'ngx-pretty-date';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ClickOutsideModule } from 'ng-click-outside';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    FontAwesomeModule,
    GoalRoutingModule,
    NgxPrettyDateModule,
    FormsModule,
    ReactiveFormsModule,
    ClickOutsideModule,
  ],
  providers: [GoalService],
  declarations: [GoalRoutingModule.components],
})
export class GoalModule {}
