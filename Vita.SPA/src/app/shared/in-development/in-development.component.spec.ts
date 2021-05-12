/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { InDevelopment } from './in-development.component';

describe('InDevelopmentComponent', () => {
  let component: InDevelopment;
  let fixture: ComponentFixture<InDevelopment>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ InDevelopment ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InDevelopment);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
