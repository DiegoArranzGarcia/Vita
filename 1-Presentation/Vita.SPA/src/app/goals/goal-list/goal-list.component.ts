import { Component, OnInit } from '@angular/core';
import { Goal } from '../goal.model';

@Component({
  selector: 'goal-list',
  templateUrl: './goal-list.component.html'
})
export class GoalListComponent implements OnInit {

  goals: Goal[];

  constructor() { }

  ngOnInit() {
    this.goals = Array(10).fill(new Goal());
  }

}
