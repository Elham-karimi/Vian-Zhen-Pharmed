import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { City } from 'src/app/models/city.model';
import { AccountService } from 'src/app/services/account.service';
import { RegisterUser } from 'src/app/models/register-user.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {

  passowrdsNotMatch: boolean | undefined;
  apiErrorMessage: string | undefined;
  cities: City[] | undefined;

  constructor(private fb: FormBuilder, private accountService: AccountService) { }

  //#region Create Form Group/controler (AbstractControl)
  registerFg = this.fb.group({
    emailCtrl: ['', [Validators.required, Validators.pattern(/^([\w\.\-]+)@([\w\-]+)((\.(\w){2,5})+)$/)]],
    passwordCtrl: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]],
    confirmPasswordCtrl: ['', [Validators.required, Validators.minLength(7), Validators.maxLength(20)]],
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
  get ConfirmPasswordCtrl(): FormControl {
    return this.registerFg.get('confirmPasswordCtrl') as FormControl;
  }
  get CityCtrl(): FormControl {
    return this.registerFg.get('cityCtrl')?.get('stateNameCtrl') as FormControl;
  }
  //#endregion

  // #region Methods
  register(): void {
    this.apiErrorMessage = undefined;

    if (this.PasswordCtrl.value === this.ConfirmPasswordCtrl.value) {
      this.passowrdsNotMatch = false;

      let user: RegisterUser = {
        email: this.EmailCtrl.value,
        password: this.PasswordCtrl.value,
        confirmpassword: this.ConfirmPasswordCtrl.value,
        city: this.CityCtrl.value
      }

      this.accountService.registerUser(user).subscribe({
        next: user => console.log(user),
        error: err => this.apiErrorMessage = err.error
      })
    }
    else {
      this.passowrdsNotMatch = true;
    }
  }

  // showCities(): void {
  //   this.http.get<City[]>('http://localhost:5000/api/city/get-all-cities').subscribe(
  //     { next: response => this.cities = response }
  //   );
  // }
}




