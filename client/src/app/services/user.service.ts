import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { Observable, map, take } from 'rxjs';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private accountService : AccountService) { }

  getAllUsers(): Observable<User[]> {
    let requestOptions;

    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: currentUser => {
          if(currentUser){
            requestOptions = {
              headers : new HttpHeaders ({'Authorization' : `Bearer ${currentUser.token}`})
            }
          }
      }
    });
    
    return this.http.get<User[]>('https://localhost:5001/api/user',requestOptions).pipe(
      map(users => {
        return users;
      })
    );
  }

  getUserById(): Observable<User>{
    return this.http.get<User>('https://localhost:5001/api/get-by-id/6579ccce1e1cd4933d4189c4').pipe(
      map(userResponse => {
        return userResponse;
      })
    )
  }
}
