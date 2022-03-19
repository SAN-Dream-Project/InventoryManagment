import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LabourRateSectionComponent } from './labour-rate-section.component';

describe('LabourRateSectionComponent', () => {
  let component: LabourRateSectionComponent;
  let fixture: ComponentFixture<LabourRateSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LabourRateSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LabourRateSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
