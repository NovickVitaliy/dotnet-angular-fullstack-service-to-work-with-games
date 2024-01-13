import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";
import {AuthenticationService} from "../authentication/services/authentication.service";

export const configureGuard: CanActivateFn = (route, state) => {
  const configurable = localStorage.getItem('configurable');
  const accessToken = localStorage.getItem('access_token');
  const authenticationService = inject(AuthenticationService);

  if(configurable && accessToken && authenticationService.userJustRegistered){
    return true;
  }
  const router = inject(Router);
  return router.navigateByUrl('/');
};
