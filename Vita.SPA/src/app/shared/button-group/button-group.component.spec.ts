/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ButtonGroup } from './button-group.component';

describe('ButtonGroupComponent', () => {
  let component: ButtonGroup;
  let fixture: ComponentFixture<ButtonGroup>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ButtonGroup ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ButtonGroup);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
