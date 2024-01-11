import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';

import { configureGuard } from './configure.guard';

describe('configureGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => configureGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
