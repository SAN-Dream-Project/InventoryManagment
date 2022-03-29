import { TestBed } from '@angular/core/testing';

import { BharadaSaleService } from './bharada-sale.service';

describe('BharadaSaleService', () => {
  let service: BharadaSaleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BharadaSaleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
