import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { GoalDto } from '../goal.model';
import { faEllipsisV, faTrashAlt, faTimes } from '@fortawesome/free-solid-svg-icons';
import { MenuOption } from 'src/app/shared/menu/menu-option.model';
import { GoalService } from '../goal.service';

@Component({
  selector: 'vita-goal-card',
  styleUrls: ['./goal-card.component.sass'],
  templateUrl: './goal-card.component.html',
})
export class GoalCardComponent implements OnInit {
  @Input() goal: GoalDto;
  @Input() deletable: boolean;

  @Output() public deleted = new EventEmitter<string>();

  goalOptions: MenuOption[];
  optionsIcon = faEllipsisV;

  constructor(private goalService: GoalService) {}

  ngOnInit() {
    this.goalOptions = [
      {
        label: 'Delete Goal',
        icon: faTimes,
        class: 'remove-option',
        action: () => {
          this.goalService.deleteGoal(this.goal.id).subscribe((_) => {
            this.deleted.emit(this.goal.id);
          });
        },
      },
    ];
  }
}
