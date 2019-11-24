import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Grupo } from 'src/app/_interfaces/grupo.model';

@Component({
  selector: 'app-grupo',
  templateUrl: './grupo.component.html',
  styleUrls: ['./grupo.component.css']
})
export class GrupoComponent implements OnInit {

  public grupos: Grupo[];
  public errorMessage: string = '';
  public apiAddress: string = 'api/materia';
  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private ngbModalService: NgbModal) { }

  ngOnInit() {
    this.getAllGrupos();
  }

  public getAllGrupos() {

    this.repository.getData(this.apiAddress)
      .subscribe(res => {
        this.grupos= res as Grupo[];
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      )
  }

}
