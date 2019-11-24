import { Component, OnInit, ViewChild } from '@angular/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { Clase, ClaseCalendario } from 'src/app/_interfaces/clases.models';
import { FullCalendarComponent } from '@fullcalendar/angular';
import { Calendar } from '@fullcalendar/core';
import esLocale from '@fullcalendar/core/locales/es';

@Component({
  selector: 'app-clases',
  templateUrl: './clases.component.html',
  styleUrls: ['./clases.component.css']
})
export class ClasesComponent implements OnInit {
  public calendarPlugins = [dayGridPlugin]; // important!
  public errorMessage: string = '';
  public calendarEvents: ClaseCalendario[] = [ 
    { title: 'Matemáticas', date: '2019-11-06' }, 
    { title: 'Matemáticas', date: '2019-11-07' }, 
    { title: 'Ingenieria', date: '2019-11-07' }
  ];
  public apiAddress: string = 'api/clases';
  public clases: Clase[];
  public locales = [esLocale];

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, ) {

   }

  ngOnInit() {
    
    this.getAllClases();

  }

  public getAllClases() {
    this.repository.getData(this.apiAddress)
      .subscribe(res => {
        this.clases = res as Clase[];
        // tslint:disable-next-line: forin

        for (let clase1 of this.clases) {
          let clase = new ClaseCalendario();
          clase.title = clase1.materia;
          clase.date = clase1.fechaClase;
          this.calendarEvents.push(clase);
        }
      },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        });

  }
}


