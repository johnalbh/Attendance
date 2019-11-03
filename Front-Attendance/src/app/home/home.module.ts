import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { AuthGuard } from '../auth/auth.guard';
import { GlobalModule } from '../global/global.module';



@NgModule({
  declarations: [
    HomeComponent,

  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: HomeComponent
      , children: [
        {path: 'materia', loadChildren: './../materia/materia.module#MateriaModule' },
        {path: 'profesores', loadChildren: './../profesores/profesores.module#ProfesoresModule' }
      ]
      , canActivate: [AuthGuard]  },

    ]),
    GlobalModule,
  ]
})
export class HomeModule { }
