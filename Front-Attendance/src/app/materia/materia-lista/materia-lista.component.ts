import { Component, OnInit } from '@angular/core';
import { Materia } from 'src/app/_interfaces/materia.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { EditarMateriaComponent } from '../editar-materia/editar-materia.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-materia-lista',
  templateUrl: './materia-lista.component.html',
  styleUrls: ['./materia-lista.component.css']
})
export class MateriaListaComponent implements OnInit {
  public materias: Materia[];
  public errorMessage: string = '';
  public apiAddress: string = "api/materia";
  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private ngbModalService: NgbModal) { }

  ngOnInit() {
    this.getAllMaterias();
  }
  public getAllMaterias() {

    this.repository.getData(this.apiAddress)
      .subscribe(res => {
        this.materias = res as Materia[];
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      )
  }
  public editarMateria(id: number) {
    const materia = this.materias.find(m => m.id === id);
    // tslint:disable-next-line: max-line-length
    const modalRef = this.ngbModalService.open(EditarMateriaComponent);
    modalRef.componentInstance.materia = materia;
  }
}

