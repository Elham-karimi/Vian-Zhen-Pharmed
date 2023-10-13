import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MushromixComponent } from './mushromix.component';

describe('MushromixComponent', () => {
  let component: MushromixComponent;
  let fixture: ComponentFixture<MushromixComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MushromixComponent]
    });
    fixture = TestBed.createComponent(MushromixComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
