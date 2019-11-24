import { Component, OnInit } from '@angular/core';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  public countAllMaterias: number = 0; 
  public errorMessage: string = '';
  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    this.getCountAllMaterias();
  }

  public getCountAllMaterias() {
    let apiAddress: string = 'api/materia/count';
    this.repository.getData(apiAddress)
      .subscribe(res => {
        this.countAllMaterias = res as number;
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      )
  }

}
