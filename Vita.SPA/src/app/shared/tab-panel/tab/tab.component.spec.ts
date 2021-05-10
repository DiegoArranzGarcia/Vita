/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Tab } from './tab.component';

describe('TabComponent', () => {
  let component: Tab;
  let fixture: ComponentFixture<Tab>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Tab ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Tab);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
