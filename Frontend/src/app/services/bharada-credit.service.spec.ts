import { TestBed } from '@angular/core/testing';

import { BharadaCreditService } from './bharada-credit.service';

describe('BharadaCreditService', () => {
  let service: BharadaCreditService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BharadaCreditService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
