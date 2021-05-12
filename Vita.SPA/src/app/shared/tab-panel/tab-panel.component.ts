import { taggedTemplate } from '@angular/compiler/src/output/output_ast';
import { AfterContentInit, AfterViewInit, Component, ContentChildren, Input, OnInit, QueryList } from '@angular/core';
import { Tab } from './tab/tab.component';

@Component({
  selector: 'vita-tab-panel',
  templateUrl: './tab-panel.component.html',
  styleUrls: ['./tab-panel.component.sass'],
})
export class TabPanel implements AfterContentInit {
  @ContentChildren(Tab) tabs: QueryList<Tab>;

  _selectedIndex: number;

  private get _tabs(): Tab[] {
    return this.tabs.toArray();
  }

  private get _selectedTab(): Tab {
    return this._tabs[this._selectedIndex];
  }

  constructor() {}

  initTabs() {
    this._selectedIndex = 0;

    this.tabs.forEach((tab, index) => {
      tab._visible = this._selectedIndex == index;
    });
  }

  ngAfterContentInit() {
    this.initTabs();
  }

  onSelectedTab(tab: Tab, index: number) {
    if (this._selectedTab) this._selectedTab._visible = false;

    this._selectedIndex = index;
    this._selectedTab._visible = true;
  }
}
