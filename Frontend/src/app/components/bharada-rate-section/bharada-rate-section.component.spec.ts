import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BharadaRateSectionComponent } from './bharada-rate-section.component';

describe('BharadaRateSectionComponent', () => {
  let component: BharadaRateSectionComponent;
  let fixture: ComponentFixture<BharadaRateSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BharadaRateSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BharadaRateSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
