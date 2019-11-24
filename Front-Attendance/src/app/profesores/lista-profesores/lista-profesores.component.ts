import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { Persona } from 'src/app/_interfaces/persona.model';
import { Profesor } from 'src/app/_interfaces/profesor.model';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EditarProfesorComponent } from '../editar-profesor/editar-profesor.component';
import { CrearProfesorComponent } from '../crear-profesor/crear-profesor.component';

@Component({
  selector: 'app-lista-profesores',
  templateUrl: './lista-profesores.component.html',
  styleUrls: ['./lista-profesores.component.css']
})
export class ListaProfesoresComponent implements OnInit {
  public profesores: Profesor[];
  public errorMessage: string = '';

  constructor(
    private router:Router, 
    private repository: RepositoryService, 
    private errorHandler: ErrorHandlerService,
    private modalService: NgbModal
  ) { }

  ngOnInit() {
    this.getAllProfesores();
  }
  public getAllProfesores(){
    let apiAddress: string = "api/profesor";
    this.repository.getData(apiAddress)
    .subscribe(res => {
      this.profesores = res as Profesor[];

    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    }
    )
  }
  public editarProfesor(tipoIdentificacion: number, numeroIdentificacion: string) {
    const profesor = this.profesores.find(m => m.tipoIdentificacion === tipoIdentificacion
       && m.numeroIdentificacion === numeroIdentificacion);
    // tslint:disable-next-line: max-line-length
    const modalRef = this.modalService.open(EditarProfesorComponent, { size: 'lg' });
    modalRef.componentInstance.profesor = profesor;
    modalRef.result.then(
      (result) => {

      }, (reason) => {
      }
    );
  }
  public crearProfesor() {
    const modalRef = this.modalService.open(CrearProfesorComponent, { size: 'lg' });
    modalRef.result.then(
      (result) => {

      }, (reason) => {

      }
    );
  }
}
