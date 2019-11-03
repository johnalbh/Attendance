import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styles: []
})
export class RegistroComponent implements OnInit {

  constructor(public service: UserService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.formModel.reset();
  }

  onSubmit() {
    this.service.register().subscribe(
      (res: any) => {
        console.log("res", res);
        if (res.succeeded) {
          this.service.formModel.reset();
          this.toastr.success('Usuario Creado!', 'Registro Exitoso.');
        } else {
          res.errors.forEach(element => {
            switch (element.code) {
              case 'DuplicateUserName':
                this.toastr.error('Ya existe el Usuario','Registro Fallo.');
                break;
              case 'PasswordRequiresNonAlphanumeric':
                  this.toastr.error('La clave debe ser Alphanumerica','Registro Fallo.');
                break;
              default:
              this.toastr.error(element.description,'RegistroFallo.');
                break;
            }
          });
        }
      },
      err => {
        console.log("Prueba", err);

        err.error.forEach(element => {
          switch (element.code) {
            case 'DuplicateUserName':
              this.toastr.error('Ya existe el Usuario','Registro Fallo.');
              break;
            case 'PasswordRequiresNonAlphanumeric':
            case 'PasswordRequiresLower':
            case 'PasswordRequiresUpper':
                this.toastr.error('La clave debe ser Alphanumerica','Registro Fallo.');
              break;
            default:
            this.toastr.error(element.description,'Registro Fallo');
              break;
          }
        });
      }
    );
  }
}
