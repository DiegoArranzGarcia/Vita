import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faArrowLeft, faArrowRight } from '@fortawesome/free-solid-svg-icons';

interface CalendarDay {
  day: number;
  month: number;
  year: number;
  otherMonth: boolean;
}

@Component({
  selector: 'vita-date-picker',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.sass'],
})
export class Calendar implements OnInit {
  _faIconArrowLeft = faArrowLeft;
  _faIconArrowRight = faArrowRight;

  readonly _weekDays: string[] = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];
  readonly _months: string[] = [
    'January',
    'Febrary',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December',
  ];

  readonly _daysInAWeek: number = 7;

  @Input() selectedDate: Date;
  @Output() selectedDateChange = new EventEmitter<Date>();

  _firstDayOfWeek: number = 0;
  _calendarWeekDays: string[];
  _calendarWeeks: CalendarDay[][];

  _currentMonth: number;
  _currentYear: number;

  ngOnInit() {
    let referenceDate = this.selectedDate ?? new Date();

    this._currentMonth = referenceDate.getMonth();
    this._currentYear = referenceDate.getFullYear();

    this.populateCalendarWeekDays();
    this.populateCalendarWeeks();
  }

  onDayClicked(day: CalendarDay) {
    if (day.otherMonth) return;

    this.selectedDateChange.emit(new Date(day.year, day.month, day.day));
  }

  isSelected(day: CalendarDay): boolean {
    if (!this.selectedDate) return false;

    return (
      this.selectedDate.getDate() === day.day && this.selectedDate.getMonth() === day.month && this.selectedDate.getFullYear() === day.year
    );
  }

  onNextMonth() {
    let nextMonth = this.getNextMonthAndYear(this._currentMonth, this._currentYear);
    this._currentMonth = nextMonth.month;
    this._currentYear = nextMonth.year;
    this.populateCalendarWeeks();
  }

  onPreviousMonth() {
    let previous = this.getPreviousMonthAndYear(this._currentMonth, this._currentYear);
    this._currentMonth = previous.month;
    this._currentYear = previous.year;
    this.populateCalendarWeeks();
  }

  private populateCalendarWeeks() {
    this._calendarWeeks = [];
    let daysInMonth = this.getDaysInMonth(this._currentMonth, this._currentYear);
    let firstDayOfMonthWeekDay = this.getFirstDayOfMonthWeekDay(this._currentMonth, this._currentYear);
    let monthRows = Math.ceil((daysInMonth + firstDayOfMonthWeekDay) / 7);

    for (let monthRow = 0; monthRow < monthRows; monthRow++) {
      if (this.isFirstWeek(monthRow)) {
        this._calendarWeeks.push(this.populateFirstWeek());
        continue;
      }

      if (this.isLastWeek(monthRow, monthRows)) {
        this._calendarWeeks.push(this.populateLastweek());
        continue;
      }

      this._calendarWeeks.push(this.populateWeek(monthRow));
    }
  }

  private populateFirstWeek(): CalendarDay[] {
    let days: CalendarDay[] = [];
    let prev = this.getPreviousMonthAndYear(this._currentMonth, this._currentYear);
    let prevMonthDaysLength = this.getDaysInMonth(prev.month, prev.year);
    let firstDayOfMonthWeekDay = this.getFirstDayOfMonthWeekDay(this._currentMonth, this._currentYear);

    for (let day = prevMonthDaysLength - firstDayOfMonthWeekDay + 1; day <= prevMonthDaysLength; day++) {
      days.push({
        day: day,
        month: prev.month,
        year: prev.year,
        otherMonth: true,
      });
    }

    let remainingDaysLength = this._daysInAWeek - days.length;
    for (let index = 0; index < remainingDaysLength; index++) {
      days.push({
        day: index + 1,
        month: this._currentMonth,
        year: this._currentYear,
        otherMonth: false,
      });
    }

    return days;
  }

  private populateWeek(monthRow: number): CalendarDay[] {
    let days: CalendarDay[] = [];
    let lastPopulatedWeek = this._calendarWeeks[monthRow - 1];
    let lastPopulatedDay = lastPopulatedWeek[lastPopulatedWeek.length - 1].day;

    for (let index = 0; index < this._daysInAWeek; index++) {
      days.push({
        day: lastPopulatedDay + 1 + index,
        month: this._currentMonth,
        year: this._currentYear,
        otherMonth: false,
      });
    }

    return days;
  }

  private populateLastweek(): CalendarDay[] {
    let days: CalendarDay[] = [];
    let daysInMonth = this.getDaysInMonth(this._currentMonth, this._currentYear);
    let nextMonth = this.getNextMonthAndYear(this._currentMonth, this._currentYear);
    let lastPopulatedWeek = this._calendarWeeks[this._calendarWeeks.length - 1];
    let lastPopulatedDay = lastPopulatedWeek[lastPopulatedWeek.length - 1].day;

    for (let index = 0; lastPopulatedDay + index + 1 <= daysInMonth; index++) {
      days.push({
        day: lastPopulatedDay + 1 + index,
        month: this._currentMonth,
        year: this._currentYear,
        otherMonth: false,
      });
    }

    let remainingDaysLength = this._daysInAWeek - days.length;
    for (let index = 0; index < remainingDaysLength; index++) {
      days.push({
        day: 1 + index,
        month: nextMonth.month,
        year: nextMonth.year,
        otherMonth: true,
      });
    }

    return days;
  }

  private populateCalendarWeekDays() {
    this._calendarWeekDays = [];
    for (let index = 0; index < this._daysInAWeek; index++) {
      let dayIndex = (this._firstDayOfWeek + index) % 7;
      let weekDay = this._weekDays[dayIndex];
      this._calendarWeekDays.push(weekDay);
    }
  }

  private isFirstWeek(index: number) {
    return index == 0;
  }

  private isLastWeek(index: number, monthRows: number) {
    return index + 1 == monthRows;
  }

  private getFirstDayOfMonthWeekDay(month: number, year: number) {
    let firstDayOfMonth = new Date(year, month, 1);
    return firstDayOfMonth.getDay();
  }

  private getDaysInMonth(month: number, year: number) {
    return new Date(year, month + 1, 0).getDate();
  }

  private getPreviousMonthAndYear(month: number, year: number) {
    if (month === 0) return { month: 11, year: year - 1 };

    return { month: month - 1, year: year };
  }

  private getNextMonthAndYear(month: number, year: number) {
    if (month === 11) return { month: 0, year: year + 1 };

    return { month: month + 1, year: year };
  }
}
