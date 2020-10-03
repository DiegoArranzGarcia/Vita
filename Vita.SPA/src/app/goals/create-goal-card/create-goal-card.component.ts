import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { GoalService } from '../goal.service';
import { faCheckCircle } from '@fortawesome/free-solid-svg-icons';
import { CreateGoalDto, GoalDto } from '../goal.model';
import { UserService } from 'src/app/core/user/user.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'vita-create-goal-card',
  templateUrl: './create-goal-card.component.html',
  styleUrls: ['./create-goal-card.component.sass'],
})
export class CreateGoalCardComponent implements OnInit {
  addIcon = faCheckCircle;
  goalForm: FormGroup;

  @Output() created = new EventEmitter<GoalDto>();

  constructor(private _goalService: GoalService, private _userService: UserService) {}

  ngOnInit() {
    this.goalForm = new FormGroup({
      titleControl: new FormControl('', [Validators.required, Validators.minLength(1)]),
      descriptionControl: new FormControl(''),
    });
  }

  onSubmit() {
    const createGoalDto: CreateGoalDto = {
      title: this.goalForm.value.titleControl,
      description: this.goalForm.value.descriptionControl,
      createdBy: this._userService.getCurrentUser().id,
    };

    this._goalService.createGoal(createGoalDto).subscribe(goal => {
      this.goalForm.reset();
      this.created.emit(goal);
    });
  }

  get title() {
    return this.goalForm.get('titleControl');
  }

  get description() {
    return this.goalForm.get('descriptionControl');
  }
}
