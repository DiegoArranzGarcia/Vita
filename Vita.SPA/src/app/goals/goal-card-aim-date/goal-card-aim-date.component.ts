import { Component, Input, OnInit, ViewChild } from '@angular/core';
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

  @Input() aimDate: DateTimeInterval;

  @ViewChild('modal') modal: ModalComponent;

  constructor() {
    this._options = ['Year', 'Month', 'Week', 'Day'];
  }

  ngOnInit() {}

  toogleAimDatePicker(event: Event) {
    this.modal.toogle();
    event.preventDefault();
  }

  onClickedOutside(event: Event) {
    this.modal.hideModal();
  }

  onOptionSelected(option: string) {}
}
