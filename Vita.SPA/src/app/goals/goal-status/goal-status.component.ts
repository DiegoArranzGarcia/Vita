import { ChangeDetectionStrategy, Component, Input, OnInit } from '@angular/core';
import { GoalStatus } from '../goal.model';

@Component({
  selector: 'vita-goal-status',
  templateUrl: './goal-status.component.html',
  styleUrls: ['./goal-status.component.sass'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GoalStatusComponent implements OnInit {
  @Input() goalStatus: GoalStatus;

  statusText: string;

  ngOnInit(): void {
    this.statusText = this.getStatusText();
  }
  
  getStatusText(): string {
    switch (this.goalStatus) {
      case GoalStatus.Completed:
        return 'Completed';
      case GoalStatus.ToDo:
        return 'To Do';
      default:
        throw new Error('Not implemented status translation');
    }
  }
}
