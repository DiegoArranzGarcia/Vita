import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'vita-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.sass'],
  animations: [
    trigger('expandAnimation', [
      state(
        'hide',
        style({
          height: '0px',
          opacity: '0',
          overflow: 'hidden',
        })
      ),
      state(
        'show',
        style({
          height: '*',
          opacity: '1',
        })
      ),
      transition('hide => show', animate('200ms ease-in')),
      transition('show => hide', animate('200ms ease-out')),
    ]),
  ],
})
export class ModalComponent implements OnInit {
  @Input() visible: boolean;

  constructor() {}

  ngOnInit() {
    this.visible = false;
  }

  onClickedOutside(event: Event) {
    if (event.defaultPrevented) return;
    this.hideModal();
  }

  toogle() {
    if (this.visible) this.hideModal();
    else this.showModal();
  }

  showModal() {
    this.visible = true;
  }

  hideModal() {
    this.visible = false;
  }
}
