import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user.model';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>('https://localhost:5001/api/user').pipe(
      map(users => {
        return users;
      })
    );
  }

  getUserById(): {
    return this.http.get<User>()
  }
}
