import { Component, OnInit, Input, EventEmitter, Output, ViewChild } from '@angular/core';
import { MenuOption } from 'src/app/shared/menu/menu-option.model';
import { GoalService } from '../goal.service';
import { faEllipsisV } from '@fortawesome/free-solid-svg-icons';
import { MenuComponent } from 'src/app/shared/menu/menu.component';

@Component({
  selector: 'vita-goal-card-menu',
  templateUrl: './goal-card-menu.component.html',
  styleUrls: ['./goal-card-menu.component.sass'],
})
export class GoalCardMenuComponent implements OnInit {
  @Input() id: string;

  @Output() deleted = new EventEmitter<string>();
  @Output() completed = new EventEmitter<string>();

  @ViewChild('menu') menu: MenuComponent;

  optionsIcon = faEllipsisV;
  goalOptions: MenuOption[];

  constructor(private goalService: GoalService) {}

  ngOnInit() {
    this.goalOptions = [
      {
        label: 'Complete Goal',
        action: () => this.goalService.completeGoal(this.id).subscribe(_ => this.completed.emit(this.id)),
      },
      {
        label: 'Delete Goal',
        class: 'remove-option',
        action: () => this.goalService.deleteGoal(this.id).subscribe(_ => this.deleted.emit(this.id)),
      },
    ];
  }

  onOptionsClicked(event: Event) {
    this.menu.toogle();
    event.preventDefault();
  }
}
