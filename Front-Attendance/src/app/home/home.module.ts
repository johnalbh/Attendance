import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { AuthGuard } from '../auth/auth.guard';
import { SidebarComponent } from '../global/sidebar/sidebar.component';
import { MateriaModule } from '../materia/materia.module';
import { HeaderComponent } from '../global/header/header.component';
import { FooterComponent } from '../global/footer/footer.component';


@NgModule({
  declarations: [
    HomeComponent,
    SidebarComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: HomeComponent
      , children: [ {path: 'materia', loadChildren: './../materia/materia.module#MateriaModule' }]
      , canActivate: [AuthGuard]  },

    ])
  ]
})
export class HomeModule { }
