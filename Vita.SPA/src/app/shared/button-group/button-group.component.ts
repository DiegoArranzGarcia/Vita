import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'vita-button-group',
  templateUrl: './button-group.component.html',
  styleUrls: ['./button-group.component.sass'],
  encapsulation: ViewEncapsulation.None,
})
export class ButtonGroup implements OnInit {
  @Input() options: string[];
  @Input() selectedOption: string;
  @Output() selectedOptionChange = new EventEmitter<string>();

  constructor() {}

  ngOnInit() {}

  onOptionSelected(option: string) {
    this.selectedOption = option;
    this.selectedOptionChange.emit(option);
  }
}
