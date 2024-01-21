import { HttpInterceptorFn } from '@angular/common/http';
import {inject} from "@angular/core";
import {AuthenticationService} from "../authentication/services/authentication.service";
import {map, take} from "rxjs";

export const emailInterceptor: HttpInterceptorFn = (req, next) => {
  const authenticationService = inject(AuthenticationService);
  authenticationService.currentUser$.pipe(take(1)).subscribe({
    next: user => {
      if(user){
        console.log("Email interceptor")
        const bodyWithEmail = {...(req.body as any), email: user.email};
        console.log(JSON.stringify(bodyWithEmail))
        req = req.clone({
          body: bodyWithEmail
        });
      }
    }
  })
  return next(req);
};
