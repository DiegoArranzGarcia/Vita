import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'vita-tab',
  templateUrl: './tab.component.html',
  styleUrls: ['./tab.component.sass'],
})
export class TabComponent implements OnInit {
  @Input() title: string;

  _visible: boolean;

  constructor() {
    this._visible = false;
  }

  ngOnInit() {}
}
