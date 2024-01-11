import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";
import {AccountService} from "../authentication/services/account.service";

export const configureGuard: CanActivateFn = (route, state) => {
  const configurable = localStorage.getItem('configurable');
  const accessToken = localStorage.getItem('access_token');
  const accountService = inject(AccountService);

  if(configurable && accessToken && accountService.userJustRegistered){
    return true;
  }
  const router = inject(Router);
  return router.navigateByUrl('/');
};
