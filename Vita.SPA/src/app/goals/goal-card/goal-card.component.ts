import { Component, OnInit, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { GoalDto as Goal } from '../goal.model';
import { GoalService } from '../goal.service';
import { FormGroup, Validators, FormControl } from '@angular/forms';
import { Subscription } from 'rxjs';

@Component({
  selector: 'vita-goal-card',
  styleUrls: ['./goal-card.component.sass'],
  templateUrl: './goal-card.component.html',
})
export class GoalCardComponent implements OnInit {
  @Input() goal: Goal;
  @Input() deletable: boolean;

  @Output() deleted = new EventEmitter<string>();
  @Output() changed = new EventEmitter<Goal>();

  updateGoalSubscription: Subscription;

  goalForm: FormGroup;
  constructor(private goalService: GoalService) {}

  ngOnInit() {
    this.goalForm = new FormGroup({
      titleControl: new FormControl(this.goal.title, [Validators.required, Validators.minLength(1)]),
      descriptionControl: new FormControl(this.goal.description),
    });
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
      });
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
