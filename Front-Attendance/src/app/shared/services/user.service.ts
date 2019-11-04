import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { UserProfile } from 'src/app/_interfaces/user.model';
import { EnvironmentUrlService } from './environment-url.service';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb: FormBuilder, private http: HttpClient, private envUrl: EnvironmentUrlService) { }
  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })

  });

  comparePasswords(fb: FormGroup) {
    const confirmPswrdCtrl = fb.get('ConfirmPassword');
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value) {
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      } else {
        confirmPswrdCtrl.setErrors(null);
      }
    }
  }

  register() {
    const body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.envUrl.urlAddress + '/api/ApplicationUser/Registro', body);
  }
  login(formData) {
    return this.http.post(this.envUrl.urlAddress + '/api/ApplicationUser/login', formData);
  }
  getPerfilUsuario(){

    return this.http.get<UserProfile>(this.envUrl.urlAddress + '/api/PerfilUsuario');
  }
  roleMatch(allowedRoles): boolean {
    let isMatch = false;
    let payLoad = JSON.parse(window.atob(localStorage.getItem('token').split('.')[1]));
    let userRole = payLoad.role;
    allowedRoles.forEach(element => {
      if (userRole === element) {
        isMatch = true;
        return false;
      }
    });
    return isMatch;
  }
}

