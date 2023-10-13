import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ColtVitaminSupplementComponent } from './colt-vitamin-supplement.component';

describe('ColtVitaminSupplementComponent', () => {
  let component: ColtVitaminSupplementComponent;
  let fixture: ComponentFixture<ColtVitaminSupplementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ColtVitaminSupplementComponent]
    });
    fixture = TestBed.createComponent(ColtVitaminSupplementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
