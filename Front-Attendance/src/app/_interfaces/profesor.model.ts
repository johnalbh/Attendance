import { Persona } from './persona.model'

export interface Profesor{
    tipoIdentificacion: number;
    numeroIdentificacion: string;
    fechaIngreso: string;
    persona: Persona[];
    grupo: any[]
}

