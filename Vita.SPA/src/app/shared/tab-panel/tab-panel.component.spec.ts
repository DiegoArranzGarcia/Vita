/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TabPanel } from './tab-panel.component';

describe('ButtonGroupComponent', () => {
  let component: TabPanel;
  let fixture: ComponentFixture<TabPanel>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TabPanel ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TabPanel);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
