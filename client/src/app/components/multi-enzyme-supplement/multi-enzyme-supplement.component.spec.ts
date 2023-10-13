import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MultiEnzymeSupplementComponent } from './multi-enzyme-supplement.component';

describe('MultiEnzymeSupplementComponent', () => {
  let component: MultiEnzymeSupplementComponent;
  let fixture: ComponentFixture<MultiEnzymeSupplementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MultiEnzymeSupplementComponent]
    });
    fixture = TestBed.createComponent(MultiEnzymeSupplementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
