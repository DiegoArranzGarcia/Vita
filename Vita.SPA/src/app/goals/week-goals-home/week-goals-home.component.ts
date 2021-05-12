import { Component, OnInit } from '@angular/core';
import { Week } from 'src/app/shared/week-picker/week-picker.component';

@Component({
  selector: 'vita-week-goals-home',
  templateUrl: './week-goals-home.component.html',
  styleUrls: ['./week-goals-home.component.sass'],
})
export class WeekGoalsHomeComponent implements OnInit {
  readonly _daysInAWeek: number = 7;

  _week: Week;

  ngOnInit() {
    let referenceDate = new Date();
    this._week = this.getWeekByDate(referenceDate);
  }

  private getWeekByDate(referenceDate: Date): Week {
    var startWeekDate: Date = new Date(referenceDate);
    startWeekDate.setDate(referenceDate.getDate() - referenceDate.getDay());

    var endWeekDate: Date = new Date(referenceDate);
    endWeekDate.setDate(referenceDate.getDate() + (6 - referenceDate.getDay()));

    return {
      startDate: startWeekDate,
      endDate: endWeekDate,
    };
  }
}
