import { Component, Input, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'vita-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.sass'],
  encapsulation: ViewEncapsulation.None,
})
export class CardComponent {
  @Input() header: string;
  @Input() meta: string;
  @Input() content: string;
  @Input() footer: string;
}
