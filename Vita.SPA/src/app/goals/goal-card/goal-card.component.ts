import { Component, OnInit, Input, Output, EventEmitter, ViewChild, OnDestroy } from '@angular/core';
import { GoalDto as Goal, GoalDto } from '../goal.model';
import { GoalService } from '../goal.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'vita-goal-card',
  styleUrls: ['./goal-card.component.sass'],
  templateUrl: './goal-card.component.html',
})
export class GoalCardComponent implements OnInit, OnDestroy {
  @Input() goal: Goal;
  @Input() deletable: boolean;

  @Output() deleted = new EventEmitter<string>();
  @Output() changed = new EventEmitter<Goal>();

  private updateGoalSubscription: Subscription;
  private refreshGoalSubscription: Subscription;

  goalForm: FormGroup;
  constructor(private goalService: GoalService) {}

  ngOnInit() {
    this.goalForm = new FormGroup({
      titleControl: new FormControl(this.goal.title, [Validators.required, Validators.minLength(1)]),
      descriptionControl: new FormControl(this.goal.description),
    });
  }

  ngOnDestroy() {
    if (this.updateGoalSubscription && !this.updateGoalSubscription.closed) this.updateGoalSubscription.unsubscribe();
    if (this.refreshGoalSubscription && !this.refreshGoalSubscription.closed) this.refreshGoalSubscription.unsubscribe();
  }

  handleOnDeleted(id: string) {
    this.deleted.emit(id);
  }

  onClickedOutside(event: Event) {
    if (!this.goalForm.dirty) return;
    if (!this.goalForm.valid) return this.restoreGoal();
    if (!this.updateGoalSubscription || !this.updateGoalSubscription.closed)
      this.updateGoalSubscription = this.updateGoal().subscribe(x => {
        this.goalForm.markAsPristine();
        this.updateGoalSubscription = null;
        this.onUpdatedGoal();
      });
  }

  onUpdatedGoal() {
    this.refreshGoalSubscription = this.refreshGoal().subscribe();
  }

  refreshGoal(): Observable<GoalDto> {
    return this.goalService.getGoal(this.goal.id).pipe(
      map(goal => {
        this.changed.emit(goal);
        return goal;
      })
    );
  }

  updateGoal() {
    return this.goalService.updateGoal(this.goal.id, {
      title: this.goalForm.controls['titleControl'].value,
      description: this.goalForm.controls['descriptionControl'].value,
    });
  }

  private restoreGoal() {
    this.goalForm.controls['titleControl'].setValue(this.goal.title);
    this.goalForm.controls['descriptionControl'].setValue(this.goal.description);
    this.goalForm.markAsPristine();
  }
}
