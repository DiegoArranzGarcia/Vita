import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { faCalendarDay, faCalendarPlus } from '@fortawesome/free-solid-svg-icons';
import { ModalComponent } from 'src/app/shared/modal/modal.component';
import { DateTimeInterval } from '../goal.model';

@Component({
  selector: 'vita-goal-card-aim-date',
  templateUrl: './goal-card-aim-date.component.html',
  styleUrls: ['./goal-card-aim-date.component.sass'],
})
export class GoalCardAimDateComponent implements OnInit {
  aimDateIcon = faCalendarDay;
  addAimDateIcon = faCalendarPlus;

  @Input() aimDate: DateTimeInterval;

  @ViewChild('modal') modal: ModalComponent;

  dates: Date;
  view: 'year' | 'month' | 'week' | 'day';

  constructor() {
    this.dates = new Date();
    this.view = 'day';
  }

  ngOnInit() {}

  toogleAimDatePicker(event: Event) {
    this.modal.toogle();
    event.preventDefault();
  }

  onClickedOutside(event: Event) {
    this.modal.hideModal();
  }
}
