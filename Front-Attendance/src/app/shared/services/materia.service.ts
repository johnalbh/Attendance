import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MateriaService {
  public progress: number;
  public message: string;
  readonly BaseURI = 'http://localhost:50250/api';
  constructor(private http: HttpClient) { }

}
