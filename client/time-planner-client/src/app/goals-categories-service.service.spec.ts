import { TestBed } from '@angular/core/testing';

import { GoalsCategoriesService } from './goals-categories-service.service';

describe('GoalsCategoriesServiceService', () => {
  let service: GoalsCategoriesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GoalsCategoriesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
