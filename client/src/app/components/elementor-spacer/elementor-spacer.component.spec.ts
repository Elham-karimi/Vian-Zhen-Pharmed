import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ElementorSpacerComponent } from './elementor-spacer.component';

describe('ElementorSpacerComponent', () => {
  let component: ElementorSpacerComponent;
  let fixture: ComponentFixture<ElementorSpacerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ElementorSpacerComponent]
    });
    fixture = TestBed.createComponent(ElementorSpacerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
