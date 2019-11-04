import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest, HttpEventType, HttpResponse } from '@angular/common/http';
import { EnvironmentUrlService } from './environment-url.service';

@Injectable({
  providedIn: 'root'
})
export class MateriaService {
  public progress: number;
  public message: string;
  public apiAddress: string = 'api/materia';
  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) { }

  public getAllMateria() {
    return this.http.get(this.envUrl.urlAddress + this.apiAddress);
  }

}
