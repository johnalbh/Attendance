import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MateriaListaComponent } from './materia-lista/materia-lista.component';
import { RouterModule } from '@angular/router';
import { MateriaService } from '../shared/services/materia.service';
import { AngularFileUploaderModule } from 'angular-file-uploader';
import { GlobalModule } from '../global/global.module';
import { EditarMateriaComponent } from './editar-materia/editar-materia.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: MateriaListaComponent }
    ]),
    AngularFileUploaderModule,
    GlobalModule,
    NgbModule,
    FormsModule,
        ReactiveFormsModule
  ],
  declarations: [
    MateriaListaComponent,
    EditarMateriaComponent
  ],
  entryComponents: [
    EditarMateriaComponent
  ],
  providers: [MateriaService]
})
export class MateriaModule { }