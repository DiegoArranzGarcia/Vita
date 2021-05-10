/* tslint:disable:no-unused-variable */
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { Spinner } from './spinner.component';

describe('LoadingComponent', () => {
  let component: Spinner;
  let fixture: ComponentFixture<Spinner>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ Spinner ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Spinner);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
