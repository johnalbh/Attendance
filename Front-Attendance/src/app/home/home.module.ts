import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { AuthGuard } from '../auth/auth.guard';
import { GlobalModule } from '../global/global.module';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MateriaModule } from '../materia/materia.module';



@NgModule({
  declarations: [
    HomeComponent,
    DashboardComponent,

  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: HomeComponent
      , children: [
        {path: 'dashboard', component: DashboardComponent },
        {path: 'materia', loadChildren: './../materia/materia.module#MateriaModule' },
        {path: 'profesores', loadChildren: './../profesores/profesores.module#ProfesoresModule' }
      ]
      , canActivate: [AuthGuard]  },

    ]),
    GlobalModule,
    MateriaModule,
  ]
})
export class HomeModule { }
