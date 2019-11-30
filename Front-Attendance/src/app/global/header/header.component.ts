import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { Router } from '@angular/router';
import { UserProfile } from 'src/app/_interfaces/user.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  userDetalle: UserProfile = {
    nombreCompleto : 'null-1',
    email: 'null-1',
    userName: 'null-1',
    tipoIdentificacion : 'null-1',
    numeroIdentificacion: 'null-1',
    primerApellido: 'null-1',
    segundoApellido: 'null-1',
    primerNombre: 'null-1',
    segundoNombre: 'null-1',
    fechaNacimiento: 'null-1',
    urlFoto: 'null-1'
  };
  private isOpen = '';
  constructor(private router: Router, private service: UserService) { }

  ngOnInit() {
    this.service.getPerfilUsuario().subscribe(
      res => {
        this.userDetalle = res;
        if (this.userDetalle !== null ){
          localStorage.setItem('personaAttendance', JSON.stringify(this.userDetalle));
        }
      },
      err => {
        console.log(err);
      }
    );
  }
  cerrarSesion(){
    localStorage.removeItem('token');
    localStorage.removeItem('personaAttendance');
    this.router.navigate(['/user/login']);
    this.userDetalle = {
      nombreCompleto : '',
      email: '', 
      userName: '',
      tipoIdentificacion : '',
      numeroIdentificacion: '',
      primerApellido: '',
      segundoApellido: '',
      primerNombre: '',
      segundoNombre: '',
      fechaNacimiento: '',
      urlFoto: ''
     };
  }

  toggled(event) {
    if (event) {
        console.log('is open');
        this.isOpen = 'is open'
    } else {
      console.log('is closed');
      this.isOpen = 'is closed'
    }
  }

}
