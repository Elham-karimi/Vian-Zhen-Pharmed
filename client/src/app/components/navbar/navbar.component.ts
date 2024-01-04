import { Component, OnInit, inject } from '@angular/core';
// import { MatIconModule } from '@angular/material/icon';
// import { MatButtonModule } from '@angular/material/button';
// import { MatToolbarModule } from '@angular/material/toolbar';
// import { MatIconRegistry } from '@angular/material/icon';
// import { AccountService } from 'src/app/services/account.service';
// import { User } from 'src/app/models/user.model';
import { Observable } from 'rxjs';
import { User } from '../../models/user.model';
import { AccountService } from '../../services/account.service';

@Component({
  standalone : true,
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit{
// user : User | null | undefined;
user$ : Observable<User | null> | undefined;
private accountService = inject(AccountService);

  ngOnInit(): void {
  this.user$ = this.accountService.currentUser$;
  }

  logout(): void {
    this.accountService.logoutUser();
  }
}
