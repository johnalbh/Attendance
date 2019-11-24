import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { Dominio } from 'src/app/_interfaces/dominio.model';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-dominios',
  templateUrl: './dominios.component.html',
  styleUrls: ['./dominios.component.css']
})
export class DominiosComponent implements OnInit {

  public errorMessage: string = '';
  public apiAddress: string = 'api/dominio';
  public dominios: Dominio[];
  closeResult: string;
  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private modalService: NgbModal) { }

  ngOnInit() {
    this.getAllDominios();
  }
  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
  public getAllDominios() {
    this.repository.getData(this.apiAddress)
      .subscribe(res => {
        this.dominios = res as Dominio[];
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      )
  }
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return  `with: ${reason}`;
    }
  }

}
