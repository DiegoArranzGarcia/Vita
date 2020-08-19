import { Component, OnInit, Input } from '@angular/core';
import { GoalService } from '../goal.service';
import { GoalDto } from '../goal.model';

@Component({
  selector: 'vita-goal-card-list',
  templateUrl: './goal-card-list.component.html',
  styleUrls: ['./goal-card-list.component.sass'],
})
export class GoalCardListComponent implements OnInit {
  goals: GoalDto[];

  @Input() canCreateGoal: boolean;

  constructor(private goalService: GoalService) {}

  ngOnInit() {
    this.goalService.getGoals().subscribe((x) => (this.goals = x));
  }

  handleOnCreated(goal: GoalDto) {
    this.goals.push(goal);
  }
}
