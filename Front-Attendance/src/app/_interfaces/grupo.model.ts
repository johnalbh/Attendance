import { Profesor } from './profesor.model'

export interface Grupo {
    id: number;
    numGrupo: number;
    idMateria: number;
    tipoIdentificacionEmpleado: string;
    numeroIdentificacionEmpleado: string;
    idMateriaNavigation: number;
    profesor: Profesor[];
    grupoHorario: any[];

}

export interface DetalleGrupo{
    id: number;
    numGrupo: number;

}

export interface GrupoHorarioSlim{
    detalleGrupo: DetalleGrupo;
}