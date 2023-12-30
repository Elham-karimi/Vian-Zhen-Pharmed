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

  getAllUsers(): Observable<User[] | null> {
      return this.http.get<User[]>('http://localhost:5000/api/user').pipe(
      map((users: User[]) => {
        if (users)
          return users;

        return null;
      })
    );
  }

  getUserById(): Observable<User | null>{
    return this.http.get<User>('http://localhost:5000/api/get-by-id/6579ccce1e1cd4933d4189c4').pipe(
      map((user: User | null) => {
        if (user)
          return user;

        return null;
      })
    )
  }
}
