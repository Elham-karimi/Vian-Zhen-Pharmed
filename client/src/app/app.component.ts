import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { User } from './models/user.model';
import { AccountService } from './services/account.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  constructor(private accountService: AccountService) { }
  
  ngOnInit(): void {
    this.getLocalStorageCurrentValues();
  }
 
  getLocalStorageCurrentValues(): void {
    const userString: string | null = localStorage.getItem('user');

    if (userString) {
      const user: User = JSON.parse(userString);

      this.accountService.setCurrentUser(user);
    }

  }
}
