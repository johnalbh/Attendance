import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { OnlyClase } from 'src/app/_interfaces/clases.models';
import { IpServiceService } from 'src/app/shared/services/ip-service.service';

@Component({
  selector: 'app-marcar-asistencia',
  templateUrl: './marcar-asistencia.component.html',
  styleUrls: ['./marcar-asistencia.component.css'],
  providers: [IpServiceService]
})
export class MarcarAsistenciaComponent implements OnInit {
  @Input() clase: OnlyClase;
  public ipAddress:string;

  constructor(    
    public activeModal: NgbActiveModal,
    private ip:IpServiceService
    ) { }

  ngOnInit() {
    this.getIP();
  }
  public getIP()
  {
    this.ip.getIPAddress().subscribe((res:any)=>{
      this.ipAddress = res.ip;
    });
  }
  onDismiss(reason : String):void {
    this.activeModal.dismiss(reason);
  }

  onClose():void {
    this.activeModal.close('closed');
  }

}
