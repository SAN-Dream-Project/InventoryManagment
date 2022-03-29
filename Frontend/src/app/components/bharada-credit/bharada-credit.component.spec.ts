import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BharadaCreditComponent } from './bharada-credit.component';

describe('BharadaCreditComponent', () => {
  let component: BharadaCreditComponent;
  let fixture: ComponentFixture<BharadaCreditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BharadaCreditComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BharadaCreditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
