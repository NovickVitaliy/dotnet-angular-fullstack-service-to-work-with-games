import {HttpInterceptorFn} from '@angular/common/http';
import {inject} from "@angular/core";
import {AuthenticationService} from "../authentication/services/authentication.service";
import {map, take} from "rxjs";

export const emailInterceptor: HttpInterceptorFn = (req, next) => {
  console.log("Email interceptor")
  console.log(req.method)
  if (req.headers.get("Content-Type") !== "multipart/form-data") {
    let userEmail;
    const authenticationService = inject(AuthenticationService);
    authenticationService.currentUser$.pipe(take(1)).subscribe({
      next: user => {
        if (user) {
          userEmail = user.email;
        }
      }
    })
    if (req.method === 'POST' || req.method === "PUT") {
      if (userEmail) {
        console.log(userEmail)
        const bodyWithEmail = {...(req.body as any), email: userEmail};
        req = req.clone({
          body: bodyWithEmail
        });
      }
    } else if (req.method === 'GET' || req.method === "DELETE") {
      if (userEmail) {
        req = req.clone({
          setParams: {
            email: userEmail
          }
        });
      }
    }
  }

  return next(req);
};
