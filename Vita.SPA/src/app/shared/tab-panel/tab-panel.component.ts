import { taggedTemplate } from '@angular/compiler/src/output/output_ast';
import { AfterContentInit, AfterViewInit, Component, ContentChildren, Input, OnInit, QueryList } from '@angular/core';
import { TabComponent } from './tab/tab.component';

@Component({
  selector: 'vita-tab-panel',
  templateUrl: './tab-panel.component.html',
  styleUrls: ['./tab-panel.component.sass'],
})
export class TabPanelComponent implements AfterContentInit {
  @ContentChildren(TabComponent) tabs: QueryList<TabComponent>;

  _selectedIndex: number;

  private get _tabs(): TabComponent[] {
    return this.tabs.toArray();
  }

  private get _selectedTab(): TabComponent {
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

  onSelectedTab(tab: TabComponent, index: number) {
    if (this._selectedTab) this._selectedTab._visible = false;

    this._selectedIndex = index;
    this._selectedTab._visible = true;
  }
}
