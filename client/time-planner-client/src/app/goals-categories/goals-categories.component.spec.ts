import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoalsCategoriesComponent } from './goals-categories.component';

describe('GoalsCategoriesComponent', () => {
  let component: GoalsCategoriesComponent;
  let fixture: ComponentFixture<GoalsCategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GoalsCategoriesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GoalsCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
