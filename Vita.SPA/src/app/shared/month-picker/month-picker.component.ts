import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faArrowLeft, faArrowRight } from '@fortawesome/free-solid-svg-icons';

export interface Month {
  month: number;
  year: number;
}

@Component({
  selector: 'vita-month-picker',
  templateUrl: './month-picker.component.html',
  styleUrls: ['./month-picker.component.sass'],
})
export class MonthPicker implements OnInit {
  readonly _faIconArrowLeft = faArrowLeft;
  readonly _faIconArrowRight = faArrowRight;
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

  @Input() selectedMonth: Month;
  @Output() selectedMonthChange = new EventEmitter<Month>();

  _currentYear: number;

  ngOnInit() {
    this._currentYear = this.selectedMonth?.year ?? new Date().getFullYear();
  }

  onNextYear() {
    this._currentYear++;
  }

  onPreviousYear() {
    this._currentYear--;
  }

  onMonthSelected(month: number) {
    let monthSelected: Month = {
      month: month,
      year: this._currentYear,
    };

    this.selectedMonthChange.emit(monthSelected);
  }
}
