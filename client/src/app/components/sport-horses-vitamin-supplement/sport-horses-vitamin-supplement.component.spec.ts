import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SportHorsesVitaminSupplementComponent } from './sport-horses-vitamin-supplement.component';

describe('SportHorsesVitaminSupplementComponent', () => {
  let component: SportHorsesVitaminSupplementComponent;
  let fixture: ComponentFixture<SportHorsesVitaminSupplementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SportHorsesVitaminSupplementComponent]
    });
    fixture = TestBed.createComponent(SportHorsesVitaminSupplementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
