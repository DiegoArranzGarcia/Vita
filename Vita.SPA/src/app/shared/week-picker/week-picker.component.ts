import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Calendar, CalendarDay, CalendarWeek } from '../calendar/calendar.component';

export interface Week {
  startDate: Date;
  endDate: Date;
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
    return this.selectedWeek?.startDate ?? new Date();
  }

  onDayClicked(day: CalendarDay, week: CalendarWeek) {
    if (day.otherMonth) return;

    let selectedCalendarWeek = this._calendarWeeks[week.monthWeek];
    let firstDayOfWeek = selectedCalendarWeek.days[0];
    let lastDayOfWeek = selectedCalendarWeek.days[this._daysInAWeek - 1];

    let selectedWeek: Week = {
      startDate: firstDayOfWeek.date,
      endDate: lastDayOfWeek.date,
    };

    this.selectedWeekChange.emit(selectedWeek);
  }

  isSelectedWeek(week: CalendarWeek): boolean {
    if (!this.selectedWeek) return false;

    let firstDayOfWeek = week.days[0];
    let lastDayOfWeek = week.days[this._daysInAWeek - 1];

    return (
      this.selectedWeek.startDate.getTime() === firstDayOfWeek.date.getTime() &&
      lastDayOfWeek.date.getTime() === this.selectedWeek.endDate.getTime()
    );
  }
}
