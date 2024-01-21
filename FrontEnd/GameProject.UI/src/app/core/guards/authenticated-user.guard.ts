import {CanActivateFn, Router} from '@angular/router';
import {inject} from "@angular/core";
import {AuthenticationService} from "../authentication/services/authentication.service";
import {map} from "rxjs";

export const authenticatedUserGuard: CanActivateFn = (route, state) => {
  const authenticationService = inject(AuthenticationService);
  const router = inject(Router);
  return authenticationService.currentUser$.pipe(map(
    user => {
      if(user){
        console.log("User logged in")
        return true;
      } else {
        console.log("User not logged in")
        return false;
      }
    }
  ));
};
