import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from '../models/user.model';
import { RegisterUser } from '../models/register-user.model';
import { Router } from '@angular/router';
import { LoginUser } from '../models/login-user.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  registerUser(userInput: RegisterUser): Observable<User | null> {
    return this.http.post<User>('https://localhost:5001/api/account/register', userInput).pipe(
      map(userResponse => {
        if (userResponse) {
          this.setCurrentUser(userResponse);
         
          this.router.navigateByUrl('/');

          return userResponse;
        } 

        return null;
      })
    );
  }

  loginUser(userInput: LoginUser): Observable<User | null> {
    return this.http.post<User>('https://localhost:5001/api/account/login', userInput).pipe(
      map(userResponse => {
        if (userResponse) {
          this.setCurrentUser(userResponse);
         
          return userResponse;
        }

        return null;
      })
    );
  }

  setCurrentUser(user: User): void {
    this.currentUserSource.next(user);

    localStorage.setItem('user', JSON.stringify(user));
  }

  logoutUser(): void {
    this.currentUserSource.next(null);

    localStorage.removeItem('user');

    this.router.navigateByUrl('/login');
  }
}
