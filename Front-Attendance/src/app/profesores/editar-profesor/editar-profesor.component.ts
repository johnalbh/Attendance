import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Profesor } from 'src/app/_interfaces/profesor.model';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-editar-profesor',
  templateUrl: './editar-profesor.component.html',
  styleUrls: ['./editar-profesor.component.css']
})
export class EditarProfesorComponent implements OnInit {
  @Input() profesor: Profesor;
  public _profesorForm: FormGroup;

  constructor(    
    private ngbModalService: NgbModal,
    private _formBuilder: FormBuilder,
    public activeModal: NgbActiveModal) { }

  ngOnInit() {
    this._profesorForm = this._formBuilder.group({
      TipoIdentificacion: [this.profesor.tipoIdentificacion],
      NumeroIdentificacion: [this.profesor.numeroIdentificacion],
      PrimeroNombre: [this.profesor.persona.primerNombre],
      SegundoNombre: [this.profesor.persona.segundoNombre],
      PrimeroApellido: [this.profesor.persona.primerApellido],
      SegundoApellido: [this.profesor.persona.segundoApellido],
      FechaNacimiento: [this.profesor.persona.fechaNacimiento],
      FechaIngreso: [this.profesor.fechaIngreso]
    });
  }
  onDismiss(reason : String):void {
    this.activeModal.dismiss(reason);
  }

  onClose():void {
    this.activeModal.close('closed');
  }

}
