import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnDestroy{
  allUsers: User[] | null | undefined;
  subscription : Subscription | undefined;

  constructor(private userService: UserService, private accountService: AccountService) { }

  ngOnDestroy(): void {
      this.subscription?.unsubscribe();
  }

  showAllUsers() {
    return this.userService.getAllUsers().subscribe({
      next: users => this.allUsers = users,
      error: err => console.log(err)
    });
  }

  logout(): void {
    this.accountService.logoutUser();
  }
}
