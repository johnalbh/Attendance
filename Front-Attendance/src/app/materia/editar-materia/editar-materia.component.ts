import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Materia } from 'src/app/_interfaces/materia.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-editar-materia',
  templateUrl: './editar-materia.component.html',
  styleUrls: ['./editar-materia.component.css']
})
export class EditarMateriaComponent implements OnInit {
  @Input() public materia: Materia;
  public _materiaForm: FormGroup;
  public errorMessage: string = '';
  public apiAddress: string = "api/materia";

  constructor(
    private _formBuilder: FormBuilder,
    private errorHandler: ErrorHandlerService,
    private repository: RepositoryService,
    public activeModal: NgbActiveModal) { }

  ngOnInit() {
    this._materiaForm = this._formBuilder.group({
      Nombre: [this.materia.nombre]
    });
    console.log(this.materia);
  }

  public onSubmit() {
    this.repository.update(this.apiAddress + '/' + this.materia.id, this._materiaForm.value)
      .subscribe(res => {
        console.log(res);

      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      )
  }
  onDismiss(reason : String):void {
    this.activeModal.dismiss(reason);
  }

  onClose():void {
    this.activeModal.close('closed');
  }

}
