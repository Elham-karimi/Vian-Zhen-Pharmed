import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginUser } from 'src/app/models/login-user.model';
import { AccountService } from 'src/app/services/account.service';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  apiErrorMessage: string | undefined;

  constructor(private accountService: AccountService, private fb: FormBuilder, private router: Router) { }

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
      next: user => {
        console.log(user);
        this.router.navigateByUrl('/');
      },
      error: err => this.apiErrorMessage = err.error
    })
  }

}

