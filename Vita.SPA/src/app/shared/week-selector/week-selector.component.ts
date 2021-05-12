import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
import { faArrowLeft, faArrowRight } from '@fortawesome/free-solid-svg-icons';
import { Week } from '../week-picker/week-picker.component';

@Component({
  selector: 'vita-week-selector',
  templateUrl: './week-selector.component.html',
  styleUrls: ['./week-selector.component.sass'],
})
export class WeekSelectorComponent {
  readonly _faIconArrowLeft = faArrowLeft;
  readonly _faIconArrowRight = faArrowRight;
  readonly _daysInAWeek: number = 7;

  @Input() week: Week;
  @Output() weekChange = new EventEmitter<Week>();

  constructor() {}

  public onPreviousWeek() {
    var firstWeekDate = new Date(this.week.startDate);
    firstWeekDate.setDate(this.week.startDate.getDate() - this._daysInAWeek);

    var endWeekDate = new Date(this.week.endDate);
    endWeekDate.setDate(this.week.endDate.getDate() - this._daysInAWeek);

    this.weekChange.emit({
      startDate: firstWeekDate,
      endDate: endWeekDate,
    });
  }

  public onNextWeek() {
    var firstWeekDate = new Date(this.week.startDate);
    firstWeekDate.setDate(this.week.startDate.getDate() + this._daysInAWeek);

    var endWeekDate = new Date(this.week.endDate);
    endWeekDate.setDate(this.week.endDate.getDate() + this._daysInAWeek);

    this.weekChange.emit({
      startDate: firstWeekDate,
      endDate: endWeekDate,
    });
  }
}
