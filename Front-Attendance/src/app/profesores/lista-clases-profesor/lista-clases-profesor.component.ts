import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { OnlyClase } from 'src/app/_interfaces/clases.models';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { MarcarAsistenciaComponent } from '../marcar-asistencia/marcar-asistencia.component';
import { UserProfile } from 'src/app/_interfaces/user.model';

@Component({
  selector: 'app-lista-clases-profesor',
  templateUrl: './lista-clases-profesor.component.html',
  styleUrls: ['./lista-clases-profesor.component.css']
})
export class ListaClasesProfesorComponent implements OnInit {
  public errorMessage: string = '';
  public clases: OnlyClase [];


  constructor(
    private repository: RepositoryService,
    private errorHandler: ErrorHandlerService,
    private modalService: NgbModal
  ) { }

  ngOnInit() {
    let Usuario: UserProfile = JSON.parse(localStorage.getItem('personaAttendance'));
    this.getAllProfesores(Usuario.tipoIdentificacion, Usuario.numeroIdentificacion);

  }
  public getAllProfesores(tipoIdentificacion: string, numeroIdentificacion: string){
    let apiAddress: string = 'api/clases/';
    this.repository.getData(apiAddress + tipoIdentificacion + '/' + numeroIdentificacion)
    .subscribe(res => {
      this.clases = res as OnlyClase[];

    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    }
    )
  }
  public marcarAsistencia(idClase: number){
    const clase = this.clases.find(m => m.idClase == idClase);
    console.log(clase);
    const modalRef = this.modalService.open(MarcarAsistenciaComponent);
    modalRef.componentInstance.clase = clase;
    modalRef.result.then(
      (result) => {

      }, (reason) => {
        
      }
    );
  }
}

