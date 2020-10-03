import { Component, OnInit, Input, ViewEncapsulation, Renderer2 } from '@angular/core';
import { MenuOption } from './menu-option.model';

@Component({
  selector: 'vita-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.sass'],
  encapsulation: ViewEncapsulation.None,
})
export class MenuComponent implements OnInit {
  @Input() options: MenuOption;

  visible: boolean;

  ngOnInit() {
    this.visible = false;
  }

  toogle() {
    if (this.visible) this.hide();
    else this.show();
  }

  show() {
    this.visible = true;
  }

  hide() {
    this.visible = false;
  }

  onOptionClicked(option: MenuOption) {
    this.visible = false;
    option.action();
  }

  onClickedOutside(event: Event) {
    if (event.defaultPrevented) return;
    this.hide();
  }
}
