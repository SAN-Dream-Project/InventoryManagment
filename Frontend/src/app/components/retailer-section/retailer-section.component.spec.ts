import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetailerSectionComponent } from './retailer-section.component';

describe('RetailerSectionComponent', () => {
  let component: RetailerSectionComponent;
  let fixture: ComponentFixture<RetailerSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RetailerSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RetailerSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
