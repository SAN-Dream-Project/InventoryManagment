import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoodPurchaseAverageRateComponent } from './good-purchase-average-rate.component';

describe('GoodPurchaseAverageRateComponent', () => {
  let component: GoodPurchaseAverageRateComponent;
  let fixture: ComponentFixture<GoodPurchaseAverageRateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoodPurchaseAverageRateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GoodPurchaseAverageRateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
