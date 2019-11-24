import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdministradorComponent } from './administrador.component';
import { RouterModule } from '@angular/router';
import { AuthGuard } from '../auth/auth.guard';
import { GlobalModule } from '../global/global.module';
import { HomeModule } from '../home/home.module';
import { DominiosComponent } from './dominios/dominios.component';
import { NgbModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ParametrosComponent } from './parametros/parametros.component';



@NgModule({
  declarations: [
    AdministradorComponent,
    DominiosComponent,
    ParametrosComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: AdministradorComponent , canActivate: [AuthGuard]  },

    ]),
    GlobalModule,
    NgbModule
  ]
})
export class AdministradorModule { }
