/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { StartUpService } from './start-up.service';

describe('Service: StartUp', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StartUpService]
    });
  });

  it('should ...', inject([StartUpService], (service: StartUpService) => {
    expect(service).toBeTruthy();
  }));
});
