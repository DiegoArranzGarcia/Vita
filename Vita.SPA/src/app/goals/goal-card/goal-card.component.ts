import { Component, OnInit, Input, Output, EventEmitter, OnDestroy } from '@angular/core';
import { Goal } from '../goal.model';
import { GoalService } from '../goal.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Observable, Subscription } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'vita-goal-card',
  styleUrls: ['./goal-card.component.sass'],
  templateUrl: './goal-card.component.html',
})
export class GoalCardComponent implements OnInit {
  @Input() goal: Goal;
  @Input() deletable: boolean;

  @Output() deleted = new EventEmitter<Goal>();
  @Output() changed = new EventEmitter<Goal>();

  goalForm: FormGroup;

  constructor(private goalService: GoalService) {}

  ngOnInit() {
    this.goalForm = new FormGroup({
      titleControl: new FormControl(this.goal.title, [Validators.required, Validators.minLength(1)]),
      descriptionControl: new FormControl(this.goal.description),
    });
  }

  handleOnDeleted(goal: Goal) {
    this.deleted.emit(goal);
  }

  handleOnCompleted(goal: Goal) {
    this.submitForm();
  }

  handleOnClickOutisde() {
    if (!this.goalForm.dirty) return;
    if (!this.goalForm.valid) return this.restoreGoal();

    this.submitForm();
  }

  handleOnAimDateChange(aimDate: { start: Date; end: Date }) {
    this.goal.aimDateStart = aimDate?.start;
    this.goal.aimDateEnd = aimDate?.end;
    this.submitForm();
  }

  submitForm() {
    this.updateGoal().subscribe(x => {
      this.goalForm.markAsPristine();
      this.refreshGoal().subscribe();
    });
  }

  refreshGoal(): Observable<Goal> {
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
