import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Dominio } from 'src/app/_interfaces/dominio.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';

@Component({
  selector: 'app-crear-profesor',
  templateUrl: './crear-profesor.component.html',
  styleUrls: ['./crear-profesor.component.css']
})
export class CrearProfesorComponent implements OnInit {
  public _profesorForm: FormGroup;
  public TiposdeIdentificacion: Dominio[];
  public errorMessage: string = '';

  constructor(
    public activeModal: NgbActiveModal,
    private repository: RepositoryService,
    private errorHandler: ErrorHandlerService,
    private _formBuilder: FormBuilder) { }

  ngOnInit() {
    this._profesorForm = this._formBuilder.group({
      TipoIdentificacion: ['', [Validators.required, Validators.minLength(2)]],
      NumeroIdentificacion: ['', [Validators.required, Validators.minLength(2)]],
      PrimeroNombre: ['', [Validators.required, Validators.minLength(2)]],
      SegundoNombre: ['', [Validators.required, Validators.minLength(2)]],
      PrimeroApellido: ['', [Validators.required, Validators.minLength(2)]],
      SegundoApellido: ['', [Validators.required, Validators.minLength(2)]],
      FechaNacimiento: ['', [Validators.required, Validators.minLength(2)]],
      FechaIngreso: ['', [Validators.required, Validators.minLength(2)]]
    });
    this.getAllTiposDocumento();
  }
  public getAllTiposDocumento(){
    this.repository.getData('api/dominio/tipoIdentificacion')
      .subscribe(res => {
        this.TiposdeIdentificacion = res as Dominio[];
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

  crearProfesor(){

    let ngbDateFN = this._profesorForm.controls['FechaNacimiento'].value;
    let myDateFN = new Date(ngbDateFN.year, ngbDateFN.month-1, ngbDateFN.day);
    let formValuesFN = this._profesorForm.value;
    formValuesFN['FechaNacimiento'] = myDateFN;
    let ngbDateFI = this._profesorForm.controls['FechaIngreso'].value;
    let myDateFI = new Date(ngbDateFI.year, ngbDateFI.month-1, ngbDateFI.day);
    let formValuesFI = this._profesorForm.value;
    formValuesFI['FechaIngreso'] = myDateFI;
    console.log(JSON.stringify(this._profesorForm.value));
  }
}
