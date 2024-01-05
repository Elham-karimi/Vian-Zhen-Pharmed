import { TestBed } from '@angular/core/testing';

import { Jwt2Interceptor } from './jwt2.interceptor';

describe('Jwt2Interceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      Jwt2Interceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: Jwt2Interceptor = TestBed.inject(Jwt2Interceptor);
    expect(interceptor).toBeTruthy();
  });
});
