import { Component, NgModule, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginUser } from '../../../models/login-user.model';
import { User } from '../../../models/user.model';
import { AccountService } from '../../../services/account.service';
import { CommonModule } from '@angular/common';




@Component({
  standalone : true,
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
  imports :[
    CommonModule, FormsModule, ReactiveFormsModule,
    
  ]
})
export class LoginComponent {
  apiErrorMessage: string | undefined;
  private accountService = inject(AccountService);
  private fb = inject(FormBuilder);
  private router = inject(Router);


  //#region FormGroup
  loginFg: FormGroup = this.fb.group({
    emailCtrl: ['', [Validators.required, Validators.pattern(/^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$/)]],
    passwordCtrl: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]]
  })

  get EmailCtrl(): FormControl {
    return this.loginFg.get('emailCtrl') as FormControl;
  }

  get PasswordCtrl(): FormControl {
    return this.loginFg.get('passwordCtrl') as FormControl;
  }
  //#endregion FormGroup

  //#region Methods
  login(): void {
    this.apiErrorMessage = undefined;

    let user: LoginUser = {
      email: this.EmailCtrl.value,
      password: this.PasswordCtrl.value
    }

    this.accountService.loginUser(user).subscribe({
      next: (user : User | null)=> {
        console.log(user);
      },
      error: err => this.apiErrorMessage = err.error
    })
  }

}

