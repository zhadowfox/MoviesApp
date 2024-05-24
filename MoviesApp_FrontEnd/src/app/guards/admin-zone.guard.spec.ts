import { TestBed } from '@angular/core/testing';
import { CanActivateFn } from '@angular/router';
import { adminZoneGuard } from './admin-zone.guard';
describe('adminZoneGuard', () => {
  const executeGuard: CanActivateFn = (...guardParameters) => 
      TestBed.runInInjectionContext(() => adminZoneGuard(...guardParameters));
  beforeEach(() => {
    TestBed.configureTestingModule({});
  });
  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
