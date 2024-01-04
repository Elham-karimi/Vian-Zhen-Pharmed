import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  standalone : true,
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent{
  allUsers: User[] | null | undefined;
  // subscription : Subscription | undefined;
 allUsers$ : Observable<User[] | null> | undefined;

  constructor(private userService: UserService, private accountService: AccountService) { }

  // ngOnDestroy(): void {
  //     this.subscription?.unsubscribe();
  // }

  showAllUsers() {
    return this.allUsers$ = this.userService.getAllUsers();
    }

  logout(): void {
    this.accountService.logoutUser();
  }
}
