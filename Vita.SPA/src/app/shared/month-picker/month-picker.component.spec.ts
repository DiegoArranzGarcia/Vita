/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MonthPicker } from './month-picker.component';

describe('MonthPickerComponent', () => {
  let component: MonthPicker;
  let fixture: ComponentFixture<MonthPicker>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MonthPicker ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MonthPicker);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
