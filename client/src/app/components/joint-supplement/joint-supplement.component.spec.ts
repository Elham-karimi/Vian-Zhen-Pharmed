import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JointSupplementComponent } from './joint-supplement.component';

describe('JointSupplementComponent', () => {
  let component: JointSupplementComponent;
  let fixture: ComponentFixture<JointSupplementComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [JointSupplementComponent]
    });
    fixture = TestBed.createComponent(JointSupplementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
