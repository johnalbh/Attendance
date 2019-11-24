import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { CrearGrupoComponent } from './grupo/crear-grupo/crear-grupo.component';

@Component({
  selector: 'app-materia',
  templateUrl: './materia.component.html',
  styleUrls: ['./materia.component.css']
})
export class MateriaComponent implements OnInit {

  constructor(private ngbModalService: NgbModal) { }

  ngOnInit() {
  }

  public crearGrupo() {
    // tslint:disable-next-line: max-line-length
    const modalRef = this.ngbModalService.open(CrearGrupoComponent, { size: 'lg' });
    modalRef.result.then(
      (result) => {

      }, (reason) => {
        
      }
    );
  }

}
