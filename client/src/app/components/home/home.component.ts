import { Component } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  allUsers : User[] | undefined;
  constructor(private userService : UserService){}
 
  showAllUsers(){
    return this.userService.getAllUsers().subscribe({
      next : users => this.allUsers = users,
      error : err => console.log(err)      
     });
  }
}
