import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { AccountService } from 'src/app/services/account.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  allUsers: User[] | undefined;
  user: User | null | undefined;

  constructor(private userService: UserService, private accountService: AccountService) { }

  ngOnInit(): void {
   this.accountService.currentUser$.subscribe({
      next: res => this.user = res
    })
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
