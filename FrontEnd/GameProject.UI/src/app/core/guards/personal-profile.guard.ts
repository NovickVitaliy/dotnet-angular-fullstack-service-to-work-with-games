import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";
import {AccountService} from "../authentication/services/account.service";
import {map} from "rxjs";

export const personalProfileGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const router = inject(Router);
  return accountService.currentUser$.pipe(map(
    user => {
      if(user){
        return true;
      } else {
        return false;
      }
    }
  ));
};
