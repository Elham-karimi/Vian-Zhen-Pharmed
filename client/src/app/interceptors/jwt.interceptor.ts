import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { AccountService } from '../services/account.service';
import { User } from '../models/user.model';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private accountService: AccountService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: (currentUser: User | null) => {
        if (currentUser) {
          request = request.clone({
            setHeaders: {
              Authorization: `Bearer ${currentUser.token}`
            }
          });
        }
      }
    });

    return next.handle(request);
  }
}
