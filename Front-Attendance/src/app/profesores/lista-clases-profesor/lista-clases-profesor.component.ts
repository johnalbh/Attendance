import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { OnlyClase } from 'src/app/_interfaces/clases.models';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { MarcarAsistenciaComponent } from '../marcar-asistencia/marcar-asistencia.component';

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
    this.getAllProfesores();
  }
  public getAllProfesores(){
    let apiAddress: string = 'api/clases/cc/1022347505';
    this.repository.getData(apiAddress)
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

