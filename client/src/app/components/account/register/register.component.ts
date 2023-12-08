import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { City } from 'src/app/models/city.model';
import {MatInputModule} from '@angular/material/input';
import {NgFor, NgIf} from '@angular/common';
import {MatSelectModule} from '@angular/material/select';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  // signupRes: SignUp | undefined;
  cities: City[] | undefined;

  constructor(private fb: FormBuilder, private accountService : AccountService) { }

  //#region Create Form Group/controler (AbstractControl)
  registerFg = this.fb.group({
    emailCtrl: ['', [Validators.required, Validators.pattern(/^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$/)]],
    passwordCtrl: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20)]],
    confirmPasswordCtrl: ['',[Validators.required, Validators.minLength(8), Validators.maxLength(20)]],
    cityCtrl: this.fb.group({
      stateNameCtrl: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(30)]]
    })
  });
  //#endregion

  //#region Forms Properties
  get EmailCtrl(): FormControl {
    return this.registerFg.get('emailCtrl') as FormControl;
  }
  get PasswordCtrl(): FormControl {
    return this.registerFg.get('passwordCtrl') as FormControl;
  }
  get ConfirmPasswordCtrl() : FormControl {
    return this.registerFg.get('confirmPasswordCtrl') as FormControl;
  }
  get CityCrl(): FormControl {
    return this.registerFg.get('cityCtrl')?.get('stateNameCtrl') as FormControl;
  }
  //#endregion

  // #region Methods
  register(): void {

    this.accountService.registerUser(user).subscribe({
        next : user => user
    })
    let signUp: SignUp = {
      email: this.EmailCtrl.value,
      password: this.PasswordCtrl.value,
      city: {
        stateName : this.CityCrl.value
      }
    }

    this.http.post<SignUp>('http://localhost5000/api/signup/register', signUp).subscribe(
      {
        next: response => {
          this.signupRes = response;
          console.log(this.signupRes);
        }
      }
    );
  }

  showCities(): void {
    this.http.get<City[]>('http://localhost:5000/api/city/get-all-cities').subscribe(
      { next: response => this.cities = response }
    );
  }
}




