import { Component, OnInit } from '@angular/core';
import { Materia } from 'src/app/_interfaces/materia.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-materia-lista',
  templateUrl: './materia-lista.component.html',
  styleUrls: ['./materia-lista.component.css']
})
export class MateriaListaComponent implements OnInit {
  public materias: Materia[];
  public errorMessage: string = '';

  constructor(private router: Router, private repository: RepositoryService, private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    this.getAllMaterias();
  }
  public getAllMaterias() {
    let apiAddress: string = "api/materia";
    this.repository.getData(apiAddress)
      .subscribe(res => {
        this.materias = res as Materia[];
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      )
  }


}
