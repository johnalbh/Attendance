import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MateriaListaComponent } from './materia-lista/materia-lista.component';
import { RouterModule } from '@angular/router';
import { MateriaService } from '../shared/services/materia.service';
import { AngularFileUploaderModule } from 'angular-file-uploader';
import { AppModule } from '../app.module';
import { GlobalModule } from '../global/global.module';
 
@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
        { path: '', component: MateriaListaComponent }
      ]),
    AngularFileUploaderModule,
    GlobalModule
  ],
  declarations: [ MateriaListaComponent  ],
  providers: [MateriaService]
})
export class MateriaModule { }