import { Component, OnInit, OnDestroy } from '@angular/core';
import { GoalService } from '../goal.service';
import { GoalDto } from '../goal.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'vita-goal-card-list',
  templateUrl: './goal-card-list.component.html',
  styleUrls: ['./goal-card-list.component.sass'],
})
export class GoalCardListComponent implements OnInit, OnDestroy {
  goals: GoalDto[];

  private getGoalsSubscription: Subscription;

  constructor(private goalService: GoalService) {}

  ngOnInit() {
    this.getGoalsSubscription = this.goalService.getGoals().subscribe(goals => {
      this.goals = goals;
    });
  }

  ngOnDestroy() {
    if (!!this.getGoalsSubscription && !this.getGoalsSubscription.closed) this.getGoalsSubscription.unsubscribe();
  }

  handleOnCreatedGoal(goal: GoalDto) {
    this.goals.push(goal);
  }

  handleOnDeleteGoal(id: string) {
    this.goals = this.goals.filter(x => x.id !== id);
  }

  handleOnChangedGoal(goal: GoalDto) {
    const index = this.goals.findIndex(x => x.id === goal.id);
    this.goals[index] = { ...goal };
  }

  get isLoading() {
    return this.getGoalsSubscription && !this.getGoalsSubscription.closed;
  }
}
