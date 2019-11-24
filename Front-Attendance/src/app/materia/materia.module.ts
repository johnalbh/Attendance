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
import { MateriaComponent } from './materia.component';
import { GrupoComponent } from './grupo/grupo.component';
import { CrearGrupoComponent } from './grupo/crear-grupo/crear-grupo.component';
import { ClasesComponent } from './clases/clases.component';
import { FullCalendarModule } from '@fullcalendar/angular';

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: MateriaComponent }
    ]),
    AngularFileUploaderModule,
    GlobalModule,
    NgbModule,
    FormsModule,
        ReactiveFormsModule,
        FullCalendarModule
  ],
  declarations: [
    MateriaListaComponent,
    EditarMateriaComponent,
    MateriaComponent,
    GrupoComponent,
    CrearGrupoComponent,
    ClasesComponent
  ],
  exports: [
    ClasesComponent
  ],
  entryComponents: [
    EditarMateriaComponent,
    CrearGrupoComponent
  ],
  providers: [MateriaService]
})
export class MateriaModule { }