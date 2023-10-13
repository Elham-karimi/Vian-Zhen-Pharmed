import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HoofMakerSupplementComponent } from './hoof-maker-supplement.component';

describe('HoofMakerSupplementComponent', () => {
  let component: HoofMakerSupplementComponent;
  let fixture: ComponentFixture<HoofMakerSupplementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [HoofMakerSupplementComponent]
    });
    fixture = TestBed.createComponent(HoofMakerSupplementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
