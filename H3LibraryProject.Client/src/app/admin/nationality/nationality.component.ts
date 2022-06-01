import { NationalityService } from './../../_services/nationality.service';
import { Nationality } from './../../_models/nationality';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nationality',
  templateUrl: './nationality.component.html',
  styleUrls: ['./nationality.component.css']
})
export class NationalityComponent implements OnInit {

  nationalities:Nationality[] = [];
  constructor(private nationalityService: NationalityService) { }


  ngOnInit(): void {
    this.nationalityService.readAllNationalities()
    .subscribe((data) => {
      console.log(data);
      this.nationalities = data;

    })
  }

}
