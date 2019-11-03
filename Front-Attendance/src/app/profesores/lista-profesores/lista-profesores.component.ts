import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { Persona } from 'src/app/_interfaces/persona.model';
import { Profesor } from 'src/app/_interfaces/profesor.model';

@Component({
  selector: 'app-lista-profesores',
  templateUrl: './lista-profesores.component.html',
  styleUrls: ['./lista-profesores.component.css']
})
export class ListaProfesoresComponent implements OnInit {
  public profesores: Profesor[];
  public errorMessage: string = '';

  constructor(private router:Router, private repository: RepositoryService, private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    this.getAllProfesores();
  }
  public getAllProfesores(){
    let apiAddress: string = "api/profesor";
    this.repository.getData(apiAddress)
    .subscribe(res => {
      this.profesores = res as Profesor[];
      console.log('res', this.profesores);
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    }
    )
  }

}
