import { Component, OnInit, Input } from '@angular/core';
import { GoalDto } from '../goal.model';

@Component({
  selector: 'vita-goal-card',
  templateUrl: './goal-card.component.html',
})
export class GoalCardComponent implements OnInit {
  @Input() goal: GoalDto;

  constructor() {}

  ngOnInit() {}
}
