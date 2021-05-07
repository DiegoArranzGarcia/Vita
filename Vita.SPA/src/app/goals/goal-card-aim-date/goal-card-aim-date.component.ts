import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { faCalendarDay, faCalendarPlus } from '@fortawesome/free-solid-svg-icons';
import { ModalComponent } from 'src/app/shared/modal/modal.component';
import { Week } from 'src/app/shared/week-picker/week-picker.component';
import { Month as Month } from 'src/app/shared/month-picker/month-picker.component';
import { CalendarWeek } from 'src/app/shared/calendar/calendar.component';

@Component({
  selector: 'vita-goal-card-aim-date',
  templateUrl: './goal-card-aim-date.component.html',
  styleUrls: ['./goal-card-aim-date.component.sass'],
})
export class GoalCardAimDateComponent implements OnInit {
  _aimDateIcon = faCalendarDay;
  _addAimDateIcon = faCalendarPlus;

  _options: string[];
  _selectedOption: string;

  @Input() aimDate: { start: Date; end: Date };
  @Output() aimDateChange = new EventEmitter<{ start: Date; end: Date }>();

  public get day(): Date {
    return this.aimDate?.start;
  }

  public get month(): Month {
    if (!this.aimDate) return null;

    return { month: this.aimDate.start.getMonth(), year: this.aimDate.start.getFullYear() };
  }

  public get week(): Week {
    if (!this.aimDate) return null;

    return { startWeekDate: this.aimDate.start, endWeekDate: this.aimDate.end };
  }

  public get year(): number {
    if (!this.aimDate) return null;

    return this.aimDate.start.getFullYear();
  }

  @ViewChild('modal') modal: ModalComponent;

  ngOnInit() {
    this._options = ['Year', 'Month', 'Week', 'Day'];
    this._selectedOption = 'Day';
  }

  toogleAimDatePicker(event: Event) {
    this.modal.toogle();
    event.preventDefault();
  }

  onSelectedDate(date: Date) {
    this.aimDateChange.emit({ start: date, end: date });
    this.modal.toogle();
  }

  onSelectedWeek(week: Week) {
    this.aimDateChange.emit({ start: week.startWeekDate, end: week.endWeekDate });
    this.modal.toogle();
  }

  onSelectedYear(year: number) {
    let startOfYear = new Date(year, 0, 1);
    let endOfYear = new Date(year, 11, 31);

    this.aimDateChange.emit({ start: startOfYear, end: endOfYear });
    this.modal.toogle();
  }

  onSelectedMonth(month: Month) {
    let firstDayOfMonth = new Date(month.year, month.month, 1);
    let lastDayOfMonth = new Date(month.year, month.month + 1, 0);

    this.aimDateChange.emit({ start: firstDayOfMonth, end: lastDayOfMonth });
    this.modal.toogle();
  }
}
