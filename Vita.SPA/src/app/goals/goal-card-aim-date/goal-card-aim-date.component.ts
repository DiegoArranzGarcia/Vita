import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { faCalendarDay, faCalendarPlus } from '@fortawesome/free-solid-svg-icons';
import { ButtonDefinition } from 'src/app/shared/tab-panel/tab-panel-definition.model';
import { ModalComponent } from 'src/app/shared/modal/modal.component';
import { DateTimeInterval } from '../goal.model';
import { Week } from 'src/app/shared/week-picker/week-picker.component';
import { Month } from 'src/app/shared/month-picker/month-picker.component';

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

  @Input() aimDate: DateTimeInterval;
  @Output() aimDateChange = new EventEmitter<DateTimeInterval>();

  @ViewChild('modal') modal: ModalComponent;

  ngOnInit() {
    this._options = ['Year', 'Month', 'Week', 'Day'];
    this._selectedOption = 'Year';
  }

  toogleAimDatePicker(event: Event) {
    this.modal.toogle();
    event.preventDefault();
  }

  onClickedOutside(event: Event) {
    this.modal.hideModal();
  }

  onSelectedDate(date: Date) {
    this.aimDateChange.emit({ start: date, end: date });
    // this.modal.toogle();
  }

  onSelectedWeek(week: Week) {
    this.aimDateChange.emit({ start: week.startWeekDate, end: week.endWeekDate });
    // this.modal.toogle();
  }

  onSelectedYear(year: number) {
    let startOfYear = new Date(year, 0, 1);
    let endOfYear = new Date(year, 11, 31);

    this.aimDateChange.emit({ start: startOfYear, end: endOfYear });
  }

  onSelectedMonth(month: Month) {
    let firstDayOfMonth = new Date(month.year, month.month, 1);
    let lastDayOfMonth = new Date(month.year, month.month + 1, 0);

    this.aimDateChange.emit({ start: firstDayOfMonth, end: lastDayOfMonth });
  }
}
