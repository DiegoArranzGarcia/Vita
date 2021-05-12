/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { YearPicker } from './year-picker.component';

describe('YearPickerComponent', () => {
  let component: YearPicker;
  let fixture: ComponentFixture<YearPicker>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [YearPicker],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YearPicker);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
