import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Calendar, CalendarDay, CalendarWeek } from '../calendar/calendar.component';

export interface Week {
  startWeekDate: Date;
  endWeekDate: Date;
}

@Component({
  selector: 'vita-week-picker',
  templateUrl: '../calendar/calendar.component.html',
  styleUrls: ['../calendar/calendar.component.sass', './week-picker.component.sass'],
})
export class WeekPicker extends Calendar implements OnInit {
  @Input() selectedWeek: Week;
  @Output() selectedWeekChange = new EventEmitter<Week>();

  ngOnInit() {
    super.ngOnInit();
  }

  protected getReferenceDate() {
    return this.selectedWeek?.startWeekDate ?? new Date();
  }

  onDayClicked(day: CalendarDay, week: CalendarWeek) {
    if (day.otherMonth) return;

    let selectedCalendarWeek = this._calendarWeeks[week.monthWeek];
    let firstDayOfWeek = selectedCalendarWeek.days[0];
    let lastDayOfWeek = selectedCalendarWeek.days[this._daysInAWeek - 1];

    let selectedWeek: Week = {
      startWeekDate: firstDayOfWeek.date,
      endWeekDate: lastDayOfWeek.date,
    };

    this.selectedWeekChange.emit(selectedWeek);
  }

  isSelectedWeek(week: CalendarWeek): boolean {
    if (!this.selectedWeek) return false;

    let firstDayOfWeek = week.days[0];
    let lastDayOfWeek = week.days[this._daysInAWeek - 1];

    return this.selectedWeek.startWeekDate === firstDayOfWeek.date && lastDayOfWeek.date === this.selectedWeek.endWeekDate;
  }
}
