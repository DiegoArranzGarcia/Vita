import { Component, OnInit, OnDestroy, Input, OnChanges, SimpleChanges } from '@angular/core';
import { GoalService } from '../goal.service';
import { Goal } from '../goal.model';
import { Subscription } from 'rxjs';

@Component({
  selector: 'vita-goal-card-list',
  templateUrl: './goal-card-list.component.html',
  styleUrls: ['./goal-card-list.component.sass'],
})
export class GoalCardListComponent implements OnInit, OnChanges, OnDestroy {
  @Input() canCreate: boolean;
  @Input() startDate: Date;
  @Input() endDate: Date;
  @Input() showCompleted: boolean;

  _goals: Goal[];

  private getGoalsSubscription: Subscription;

  constructor(private goalService: GoalService) {}

  ngOnInit() {
    this.loadGoals();
  }

  ngOnChanges(changes: SimpleChanges): void {
    let startDateChange = changes['startDate'];
    let endDateChange = changes['endDate'];

    if (startDateChange?.currentValue || endDateChange?.currentValue) {
      this.loadGoals();
    }
  }

  ngOnDestroy() {
    if (!!this.getGoalsSubscription && !this.getGoalsSubscription.closed) this.getGoalsSubscription.unsubscribe();
  }

  loadGoals() {
    this.getGoalsSubscription = this.goalService.getGoals(this.startDate, this.endDate, this.showCompleted).subscribe(goals => {
      this._goals = goals;
    });
  }

  handleOnCreatedGoal(goal: Goal) {
    this._goals = [goal, ...this._goals];
  }

  handleOnDeleteGoal(goal: Goal) {
    this._goals = this._goals.filter(x => x.id !== goal.id);
  }

  handleOnChangedGoal(goal: Goal) {
    const index = this._goals.findIndex(x => x.id === goal.id);
    this._goals[index] = { ...goal };
  }

  get isLoading() {
    return this.getGoalsSubscription && !this.getGoalsSubscription.closed;
  }
}
