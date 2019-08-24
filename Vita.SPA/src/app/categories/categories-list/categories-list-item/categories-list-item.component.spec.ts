import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoriesListItemComponent } from './categories-list-item.component';

describe('CategoriesListItemComponent', () => {
  let component: CategoriesListItemComponent;
  let fixture: ComponentFixture<CategoriesListItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CategoriesListItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoriesListItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
