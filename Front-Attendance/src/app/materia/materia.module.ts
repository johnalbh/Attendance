import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MateriaListaComponent } from './materia-lista/materia-lista.component';
import { RouterModule } from '@angular/router';
 
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
        { path: 'list', component: MateriaListaComponent }
      ])
  ],
  declarations: [MateriaListaComponent]
})
export class MateriaModule { }