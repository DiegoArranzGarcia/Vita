import { animate, state, style, transition, trigger } from '@angular/animations';
import { Component, Input, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'vita-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.sass'],
  encapsulation: ViewEncapsulation.None,
  animations: [
    trigger('inOutAnimation', [
      transition(':enter', [style({ height: 0, opacity: 0 }), animate('200ms ease-out', style({ height: '*', opacity: 1 }))]),
      transition(':leave', [style({ height: '*', opacity: 1 }), animate('200ms ease-in', style({ height: 0, opacity: 0 }))]),
    ]),
  ],
})
export class ModalComponent implements OnInit {
  @Input() visible: boolean;

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
