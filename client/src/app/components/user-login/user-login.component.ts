import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { AdminLogin } from 'src/app/models/admin-login.model';
import { Admin } from 'src/app/models/admin.model';
import { Login } from 'src/app/models/login.model';
import { SignUp } from 'src/app/models/signup.model';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.scss']
})
export class UserLoginComponent {
  loginRes: SignUp | undefined;

  constructor(private fb: FormBuilder, private http: HttpClient) { }

  loginFg = this.fb.group({
    emailCtrl: ['', [Validators.required, Validators.pattern(/^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$/)]],
    passwordCtrl: ['', [Validators.required, Validators.minLength(8)]],
  });


  get EmailCtrl(): FormControl {
    return this.loginFg.get('emailCtrl') as FormControl;
  }
  get PasswordCtrl(): FormControl {
    return this.loginFg.get('passwordCtrl') as FormControl;
  }

  loginUser(): void {
    let AdminLogin: AdminLogin = {
      email: this.EmailCtrl.value,
      password: this.PasswordCtrl.value,
    }

    this.http.post<SignUp>('http://localhost5000/api/account/login', AdminLogin).subscribe(
      {
        next: response => {
          this.loginRes = response;
          // console.log(this.loginRes);
        }
      }
    );
  }
}
