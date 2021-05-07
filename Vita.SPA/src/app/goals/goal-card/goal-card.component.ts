import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { GoalDto } from '../goal.model';
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
  @Input() goal: GoalDto;
  @Input() deletable: boolean;

  @Output() deleted = new EventEmitter<string>();
  @Output() changed = new EventEmitter<GoalDto>();

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

  submitForm() {
    if (!this.goalForm.dirty) return;
    if (!this.goalForm.valid) return this.restoreGoal();
    this.updateGoalCard();
  }

  updateGoalCard() {
    if (this.updateGoalSubscription && this.updateGoalSubscription.closed) return;

    this.updateGoalSubscription = this.updateGoal().subscribe(x => {
      this.goalForm.markAsPristine();
      this.updateGoalSubscription = null;
      this.onUpdatedGoal();
    });
  }

  onUpdatedGoal() {
    this.refreshGoalSubscription = this.refreshGoal().subscribe();
  }

  onClickOutisde() {
    this.submitForm();
  }

  onAimDateChange(aimDate: { start: Date; end: Date }) {
    this.goal.aimDateStart = aimDate?.start;
    this.goal.aimDateEnd = aimDate?.end;
    this.updateGoalCard();
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
      aimDateStart: this.goal.aimDateStart,
      aimDateEnd: this.goal.aimDateEnd,
    });
  }

  private restoreGoal() {
    this.goalForm.controls['titleControl'].setValue(this.goal.title);
    this.goalForm.controls['descriptionControl'].setValue(this.goal.description);
    this.goalForm.markAsPristine();
  }
}
