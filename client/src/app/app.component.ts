import { Component, OnInit, PLATFORM_ID, inject } from '@angular/core';
import { CommonModule, isPlatformBrowser } from '@angular/common';
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
  [x: string]: any;
  private accountService = inject(AccountService);
  platformId = inject(PLATFORM_ID);

  ngOnInit(): void {
    this.getLocalStorageCurrentValues();
  }

  getLocalStorageCurrentValues(): void {
    let userString: string | null = null;

    if (isPlatformBrowser(this.platformId))
      userString = localStorage.getItem('user');

    if (userString) {
      const user: User = JSON.parse(userString);

      this.accountService.setCurrentUser(user);
    }

  }
}
