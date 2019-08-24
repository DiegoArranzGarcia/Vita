import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GoalListItemComponent } from './goal-list-item.component';

describe('GoalListItemComponent', () => {
  let component: GoalListItemComponent;
  let fixture: ComponentFixture<GoalListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GoalListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GoalListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
