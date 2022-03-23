import { TestBed } from '@angular/core/testing';

import { KadataService } from './kadata.service';

describe('KadataService', () => {
  let service: KadataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(KadataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
