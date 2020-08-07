import { Component, OnInit, Input } from '@angular/core';
import { GoalService } from '../goal.service';
import { Goal } from '../goal.model';
import { faPlus } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'vita-goal-list',
  templateUrl: './goal-list.component.html',
  styleUrls: ['./goal-list.component.sass'],
})
export class GoalListComponent implements OnInit {
  goals: Goal[];
  plusIcon = faPlus;

  @Input() canCreateGoal: boolean;

  constructor(private goalService: GoalService) {}

  ngOnInit() {  
    this.goalService.getGoals().subscribe((x) => (this.goals = x));
  }

  addCreationCard(){
    
  }
}
