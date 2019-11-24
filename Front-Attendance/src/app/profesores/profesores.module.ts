import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaProfesoresComponent } from './lista-profesores/lista-profesores.component';
import { RouterModule } from '@angular/router';
import { EditarProfesorComponent } from './editar-profesor/editar-profesor.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CrearProfesorComponent } from './crear-profesor/crear-profesor.component';
import { MarcarAsistenciaComponent } from './marcar-asistencia/marcar-asistencia.component';
import { DashboardProfesorComponent } from './dashboard-profesor/dashboard-profesor.component';
import { ListaClasesProfesorComponent } from './lista-clases-profesor/lista-clases-profesor.component';



@NgModule({
  declarations: [
    ListaProfesoresComponent,
    EditarProfesorComponent,
    CrearProfesorComponent,
    MarcarAsistenciaComponent,
    DashboardProfesorComponent,
    ListaClasesProfesorComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', component: ListaProfesoresComponent },
      { path: 'dashboard', component: DashboardProfesorComponent}
    ]),
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    EditarProfesorComponent,
    CrearProfesorComponent,
    MarcarAsistenciaComponent
  ]

})
export class ProfesoresModule { }
