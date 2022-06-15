import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.css']
})
export class AdminLayoutComponent implements OnInit {

  adminPages:string[] = ['author','genre','language','loan','loaner','loanertype','location','material','nationality','publisher','title'];

  constructor() { }

  ngOnInit(): void {
  }

}
