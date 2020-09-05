import { Component, OnInit, Input, ChangeDetectionStrategy, ViewEncapsulation, Renderer2 } from '@angular/core';
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
  documentClickListener: any;
  preventDocumentDefault: any;

  constructor(public renderer: Renderer2) {}

  ngOnInit() {}

  toogle() {
    this.preventDocumentDefault = true;
    if (this.visible) this.hide();
    else this.show();
  }

  show() {
    this.visible = true;
    this.bindDocumentClickListener();
  }

  hide() {
    this.visible = false;
    this.unbindDocumentClickListener();
  }

  bindDocumentClickListener() {
    if (!this.documentClickListener) {
      this.documentClickListener = this.renderer.listen('document', 'click', () => {
        if (!this.preventDocumentDefault) {
          this.hide();
        }

        this.preventDocumentDefault = false;
      });
    }
  }

  unbindDocumentClickListener() {
    if (this.documentClickListener) {
      this.documentClickListener();
      this.documentClickListener = null;
    }
  }
}
