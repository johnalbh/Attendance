import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../shared/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  userDetalle;

  public homeText: string;
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
    this.homeText = "WELCOME TO ACCOUNT-OWNER APPLICATION";
  }

}
