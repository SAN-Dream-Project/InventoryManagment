import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BharadaSaleComponent } from './bharada-sale.component';

describe('BharadaSaleComponent', () => {
  let component: BharadaSaleComponent;
  let fixture: ComponentFixture<BharadaSaleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BharadaSaleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BharadaSaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
