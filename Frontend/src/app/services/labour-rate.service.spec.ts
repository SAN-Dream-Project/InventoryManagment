import { TestBed } from '@angular/core/testing';

import { LabourRateService } from './labour-rate.service';

describe('LabourRateService', () => {
  let service: LabourRateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LabourRateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
