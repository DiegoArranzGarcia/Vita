import { Component, OnInit, Input } from '@angular/core';
import { Goal } from '../goal.model';

@Component({
  selector: 'vita-goal-item',
  templateUrl: './goal-item.component.html',
  styleUrls: ['./goal-item.component.sass'],
})
export class GoalItemComponent implements OnInit {
  @Input() goal: Goal;

  constructor() {}

  ngOnInit() {}
}
