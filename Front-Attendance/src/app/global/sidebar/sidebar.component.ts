import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Version } from 'src/environments/version';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {

  public version = Version.version;
  constructor() { }

  ngOnInit() {
  }

}
