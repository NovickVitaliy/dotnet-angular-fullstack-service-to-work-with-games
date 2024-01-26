import {CanActivateFn} from '@angular/router';

export const confirmEmailGuard: CanActivateFn = (route, state) => {
  const email = route.queryParams['email']
  const token = route.queryParams['token'];
  console.log(email)
  console.log(token)
  if (email && token) {
    return true;
  }
  return false;
};
