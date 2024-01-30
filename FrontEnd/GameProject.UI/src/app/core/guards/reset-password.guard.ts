import {CanActivateFn} from '@angular/router';

export const resetPasswordGuard: CanActivateFn = (route, state) => {
  const token = route.queryParams['token'];
  const email = route.queryParams['email'];

  if (token && email) {
    return true;
  }
  return false;
};
