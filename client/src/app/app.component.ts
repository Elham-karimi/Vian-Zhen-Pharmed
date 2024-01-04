import { Component, OnInit } from '@angular/core';
import { User } from './models/user.model';
import { AccountService } from './services/account.service';
// import { faCoffee } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
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