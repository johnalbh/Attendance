import { Persona } from './persona.model'

export interface Profesor {
    tipoIdentificacion: number;
    numeroIdentificacion: string;
    fechaIngreso: Date;
    persona: Persona;
    grupo: any[];
}

export interface ProfesorConsulta {
    tipoIdentificacion: number;
    numeroIdentificacion: string;
    primerNombre: string;
    segundoNombre: string;
    primerApellido: string;
    segundoApellido: string;
    urlFoto: string;
}

