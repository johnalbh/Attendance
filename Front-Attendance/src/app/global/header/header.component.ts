import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  userDetalle;
  constructor(private router: Router, private service: UserService) { }

  ngOnInit() {
    this.service.getPerfilUsuario().subscribe(
      res => {
        this.userDetalle = res;
        console.log(res);
      },
      err => {
        console.log(err)
      }
    );
  }
  cerrarSesion(){
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }

}
