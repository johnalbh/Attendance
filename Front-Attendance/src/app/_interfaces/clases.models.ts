import { Time } from '@angular/common'
import { ProfesorConsulta } from './profesor.model';
import { DetalleGrupo, GrupoHorarioSlim } from './grupo.model';

export interface Clase {
    idClase: number;
    asistencia: boolean;
    fechaClase: string;
    materia: string;
    grupo: number;
    profesor: ProfesorConsulta;

}

export class ClaseCalendario{
    title: string;
    date: string;
}

export interface OnlyClase {
    idClase: number;
    asistencia: boolean;
    fechaClase: string;
    materia: string;
    horaInicio: string;
    horaFin: string;
    grupo: GrupoHorarioSlim;
}


