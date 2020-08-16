import { Component, OnInit } from '@angular/core';
import { faPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'vita-goal-home',
  templateUrl: './goal-home.component.html',
  styleUrls: ['./goal-home.component.sass'],
})
export class GoalHomeComponent implements OnInit {
  plusIcon = faPlus;

  constructor() {}

  ngOnInit() {}
}
