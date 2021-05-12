/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { WeekPicker } from './week-picker.component';

describe('WeekPickerComponent', () => {
  let component: WeekPicker;
  let fixture: ComponentFixture<WeekPicker>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [WeekPicker],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WeekPicker);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
