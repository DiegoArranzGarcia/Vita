import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { faArrowLeft, faArrowRight } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'vita-year-picker',
  templateUrl: './year-picker.component.html',
  styleUrls: ['./year-picker.component.sass'],
})
export class YearPicker implements OnInit {
  readonly _faIconArrowLeft = faArrowLeft;
  readonly _faIconArrowRight = faArrowRight;

  @Input() selectedYear: number;
  @Output() selectedYearChange = new EventEmitter<number>();

  _years: number[];
  _refenceYear: number;

  ngOnInit() {
    this._refenceYear = this.selectedYear ?? new Date().getFullYear();
    this.populateYears();
  }

  onNextYears() {
    this._refenceYear += 12;
    this.populateYears();
  }

  onPreviousYears() {
    this._refenceYear -= 12;
    this.populateYears();
  }

  onYearSelected(year: number) {
    this.selectedYearChange.emit(year);
  }

  private populateYears() {
    this._years = [];

    for (let year = this._refenceYear - 6; year < this._refenceYear + 6; year++) {
      this._years.push(year);
    }
  }
}
