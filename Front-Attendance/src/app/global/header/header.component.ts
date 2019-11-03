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
  userDetalle: UserProfile = {    fullName : 'null-1',  email: 'null-2',  userName: 'null-3' };
  constructor(private router: Router, private service: UserService) { }

  ngOnInit() {
    this.service.getPerfilUsuario().subscribe(
      res => {
        this.userDetalle = res;
      },
      err => {
        console.log(err);
      }
    );
  }
  cerrarSesion(){
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
    this.userDetalle = {    fullName : '',  email: '',  userName: '' };
  }

}
