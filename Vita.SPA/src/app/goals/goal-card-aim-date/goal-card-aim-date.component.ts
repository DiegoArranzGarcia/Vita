import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { faCalendarDay, faCalendarPlus } from '@fortawesome/free-solid-svg-icons';
import { ButtonDefinition } from 'src/app/shared/tab-panel/tab-panel-definition.model';
import { ModalComponent } from 'src/app/shared/modal/modal.component';
import { DateTimeInterval } from '../goal.model';

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
    this._selectedOption = 'Day';
  }

  toogleAimDatePicker(event: Event) {
    this.modal.toogle();
    event.preventDefault();
  }

  onClickedOutside(event: Event) {
    this.modal.hideModal();
  }

  onSelectedDate(date: Date) {
    if (this._selectedOption == 'Day') {
      this.aimDateChange.emit({ start: date, end: date });
      return;
    }

    if (this._selectedOption == 'Month') {
      var endDate = new Date(date);
      endDate.setMonth(endDate.getMonth() + 1);
      this.aimDateChange.emit({ start: date, end: endDate });
      return;
    }

    this.modal.toogle();
  }
}
