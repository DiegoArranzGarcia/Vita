import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Calendar, CalendarDay, CalendarWeek } from '../calendar/calendar.component';

@Component({
  selector: 'vita-date-picker',
  templateUrl: '../calendar/calendar.component.html',
  styleUrls: ['../calendar/calendar.component.sass', './date-picker.component.sass'],
})
export class DatePicker extends Calendar implements OnInit {
  @Input() selectedDate: Date;
  @Output() selectedDateChange = new EventEmitter<Date>();

  ngOnInit() {
    super.ngOnInit();
  }

  protected getReferenceDate() {
    return this.selectedDate ?? new Date();
  }

  onDayClicked(calendarDay: CalendarDay, calendarWeek: CalendarWeek) {
    if (calendarDay.otherMonth) return;

    this.selectedDateChange.emit(calendarDay.date);
  }

  isSelectedDay(calendarDay: CalendarDay): boolean {
    if (!this.selectedDate) return false;

    return this.selectedDate.getTime() === calendarDay.date.getTime();
  }

  isSelectedWeek(calendarWeek: CalendarWeek): boolean {
    return false;
  }
}
