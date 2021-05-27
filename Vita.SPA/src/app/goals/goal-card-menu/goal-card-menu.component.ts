import { Component, OnInit, Input, EventEmitter, Output, ViewChild } from '@angular/core';
import { MenuOption } from 'src/app/shared/menu/menu-option.model';
import { GoalService } from '../goal.service';
import { faEllipsisV } from '@fortawesome/free-solid-svg-icons';
import { ModalComponent } from 'src/app/shared/modal/modal.component';
import { Goal as Goal, GoalStatus } from '../goal.model';

@Component({
  selector: 'vita-goal-card-menu',
  templateUrl: './goal-card-menu.component.html',
  styleUrls: ['./goal-card-menu.component.sass'],
})
export class GoalCardMenuComponent implements OnInit {
  @Input() goal: Goal;

  @Output() deleted = new EventEmitter<Goal>();
  @Output() completed = new EventEmitter<Goal>();

  @ViewChild('modal') modal: ModalComponent;

  optionsIcon = faEllipsisV;
  goalOptions: MenuOption[];

  constructor(private goalService: GoalService) {}

  ngOnInit() {
    this.goalOptions = [
      {
        label: 'Complete Goal',
        action: () => this.goalService.completeGoal(this.goal.id).subscribe(_ => this.completed.emit(this.goal)),
        show: () => this.goal.status !== GoalStatus.Completed,
      },
      {
        label: 'Delete Goal',
        class: 'remove-option',
        action: () => this.goalService.deleteGoal(this.goal.id).subscribe(_ => this.deleted.emit(this.goal)),
      },
    ];
  }

  onOptionsClicked(event: Event) {
    this.modal.toogle();
    event.preventDefault();
  }
}
