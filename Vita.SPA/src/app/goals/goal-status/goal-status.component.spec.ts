/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { GoalStatusLabelComponent } from './goal-status.component';

describe('GoalStatusLabelComponent', () => {
  let component: GoalStatusLabelComponent;
  let fixture: ComponentFixture<GoalStatusLabelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GoalStatusLabelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GoalStatusLabelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
