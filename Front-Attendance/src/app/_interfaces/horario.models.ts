import { Time } from '@angular/common';

export interface HorarioConDia{
    id: number;
    dia: number;
    nombreDia: string;
    horaInicio: Time;
    horaFin: Time;
}