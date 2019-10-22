import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserComponent } from './user.component';
import { Routes, RouterModule, PreloadAllModules  } from '@angular/router';
import { RegistroComponent } from './registro/registro.component';
import { UserService } from '../shared/services/user.service';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from '../auth/auth.guard';


@NgModule({
  declarations: [UserComponent, RegistroComponent, LoginComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      { path: '', component: UserComponent,
              children: [
          {path: 'registro', component: RegistroComponent},
          {path: 'login', component: LoginComponent}
        ]
    }
    ])
  ],
  providers: [UserService],
})
export class UserModule { }
