import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VianAmbassadorsComponent } from './vian-ambassadors.component';

describe('VianAmbassadorsComponent', () => {
  let component: VianAmbassadorsComponent;
  let fixture: ComponentFixture<VianAmbassadorsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VianAmbassadorsComponent]
    });
    fixture = TestBed.createComponent(VianAmbassadorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
