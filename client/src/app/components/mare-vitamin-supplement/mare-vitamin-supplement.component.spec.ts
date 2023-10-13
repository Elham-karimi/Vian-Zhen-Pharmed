import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MareVitaminSupplementComponent } from './mare-vitamin-supplement.component';

describe('MareVitaminSupplementComponent', () => {
  let component: MareVitaminSupplementComponent;
  let fixture: ComponentFixture<MareVitaminSupplementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MareVitaminSupplementComponent]
    });
    fixture = TestBed.createComponent(MareVitaminSupplementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
