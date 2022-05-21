import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GoodsSupplierSectionComponent } from './goods-supplier-section.component';

describe('GoodsSupplierSectionComponent', () => {
  let component: GoodsSupplierSectionComponent;
  let fixture: ComponentFixture<GoodsSupplierSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GoodsSupplierSectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GoodsSupplierSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
