import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LabourSectionComponent } from './labour-section.component';

describe('LabourSectionComponent', () => {
  let component: LabourSectionComponent;
  let fixture: ComponentFixture<LabourSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LabourSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LabourSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
