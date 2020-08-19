import { Component, OnInit } from '@angular/core';
import { faRocket } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'vita-goal-home',
  templateUrl: './goal-home.component.html',
  styleUrls: ['./goal-home.component.sass'],
})
export class GoalHomeComponent implements OnInit {
  goalsIcon = faRocket;

  constructor() {}

  ngOnInit() {}
}
