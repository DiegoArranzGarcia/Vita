import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'vita-button-group',
  templateUrl: './button-group.component.html',
  styleUrls: ['./button-group.component.sass'],
  encapsulation: ViewEncapsulation.None,
})
export class ButtonGroupComponent implements OnInit {
  @Input() options: string[];

  @Output('option') optionSelected = new EventEmitter<string>();

  _selectedOption: number;

  constructor() {
    this._selectedOption = 0;
  }

  ngOnInit() {}

  onOptionSelected(option: string) {
    this._selectedOption = this.options.findIndex(value => value === option);
    this.optionSelected.emit(option);
  }
}
