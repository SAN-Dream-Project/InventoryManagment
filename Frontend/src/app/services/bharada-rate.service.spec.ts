import { TestBed } from '@angular/core/testing';

import { BharadaRateService } from './bharada-rate.service';

describe('BharadaRateService', () => {
  let service: BharadaRateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BharadaRateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
