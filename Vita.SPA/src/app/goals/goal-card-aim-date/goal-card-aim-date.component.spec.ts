/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GoalCardAimDateComponent } from './goal-card-aim-date.component';

describe('GoalCardAimDateComponent', () => {
  let component: GoalCardAimDateComponent;
  let fixture: ComponentFixture<GoalCardAimDateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GoalCardAimDateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GoalCardAimDateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
