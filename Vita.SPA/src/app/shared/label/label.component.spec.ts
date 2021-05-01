/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Label } from './label.component';

describe('LabelComponent', () => {
  let component: Label;
  let fixture: ComponentFixture<Label>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ Label ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Label);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
