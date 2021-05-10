/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Calendar } from './calendar.component';

describe('CalendarComponent', () => {
  let component: Calendar;
  let fixture: ComponentFixture<Calendar>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Calendar ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Calendar);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
