import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaProfesoresComponent } from './lista-profesores/lista-profesores.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [ListaProfesoresComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: ListaProfesoresComponent}])
  ]
})
export class ProfesoresModule { }
