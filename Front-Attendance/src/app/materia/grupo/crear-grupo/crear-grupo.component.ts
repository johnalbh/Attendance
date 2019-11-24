import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, FormArray, Validators } from '@angular/forms';
import { Materia } from 'src/app/_interfaces/materia.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Dominio } from 'src/app/_interfaces/dominio.model';
import { HorarioConDia } from 'src/app/_interfaces/horario.models';

@Component({
  selector: 'app-crear-grupo',
  templateUrl: './crear-grupo.component.html',
  styleUrls: ['./crear-grupo.component.css']
})
export class CrearGrupoComponent implements OnInit {

  public _materiaForm: FormGroup;
  public materias: Materia[] = [];
  public ListadiasSemana: Dominio[];
  public horarioConDiaInicio: HorarioConDia[] = [];
  public horarioConDiaFin: HorarioConDia[] = [];
  public horarioConDiaInicio_1: HorarioConDia[] = [];
  public horarioConDiaFin_2: HorarioConDia[] = [];
  public errorMessage: string = '';
  public apiAddress: string = 'api/materia';


  constructor(
    private _formBuilder: FormBuilder,
    private repository: RepositoryService,
    private errorHandler: ErrorHandlerService,
    private ngbModalService: NgbModal,
    public activeModal: NgbActiveModal
    
  ) { }

  ngOnInit() {
    this._materiaForm = this._formBuilder.group({
      Materia: ['', [
                      Validators.required,
                      Validators.minLength(2)
                    ]
                ],
      Nombre: ['', [
                      Validators.required, 
                      Validators.minLength(2)
                    ]
              ],
      NumeroHoras: ['', [Validators.required, Validators.minLength(2)]],
      DiasSemana: this._formBuilder.array([this._formBuilder.group({
        dia: ['', Validators.required],
        horaInicio: ['', Validators.required],
        horaFin: ['', Validators.required],
      })])
    });
    this.getAllMaterias();
    this.getAllDiasSemana();
    this.getAllHorarioConDia();
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
  public getAllDiasSemana(){
    this.repository.getData('api/dominio/diaSemana')
      .subscribe(res => {
        this.ListadiasSemana = res as Dominio[];
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        }
      )
  }
  public getAllHorarioConDia(){
    this.repository.getData('api/horario/connombredia')
      .subscribe(res => {
        this.horarioConDiaInicio = res as HorarioConDia[];
        this.horarioConDiaFin = res as HorarioConDia[];
        this.horarioConDiaInicio_1 = this.horarioConDiaInicio;
        this.horarioConDiaFin_2 = this.horarioConDiaFin;
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        }
     )
  }

  ///////// This is new ////////
  get diasSemana() {
    return this._materiaForm.get('DiasSemana') as FormArray;
  }

  onSelect(numdia: Number) {

    this.horarioConDiaInicio_1 = this.horarioConDiaInicio;
    this.horarioConDiaInicio_1 = this.horarioConDiaInicio_1.filter((item) => Number(item.dia) === Number(numdia));
   
    this.horarioConDiaFin_2 = this.horarioConDiaFin;
    this.horarioConDiaFin_2 = this.horarioConDiaFin_2.filter((item) => Number(item.dia) === Number(numdia));


  }

  addDiaSemana() {

    if (this.diasSemana.controls.length < 7) {
      this.diasSemana.push(this._formBuilder.group({
        dia: [''],
        horaInicio: [''],
        horaFin: [''],
      }));
    }

  }

  deleteDiaSemana(index) {
    this.diasSemana.removeAt(index);
  }
  onDismiss(reason : String):void {
    this.activeModal.dismiss(reason);
  }

  onClose():void {
    this.activeModal.close('closed');
    this._materiaForm.reset();
  }
  crearGrupo(){
    console.log(this._materiaForm.value)
  }
}
