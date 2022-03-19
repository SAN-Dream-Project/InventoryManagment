import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KadataSectionComponent } from './kadata-section.component';

describe('KadataSectionComponent', () => {
  let component: KadataSectionComponent;
  let fixture: ComponentFixture<KadataSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KadataSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KadataSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
