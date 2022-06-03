import { NationalityService } from './../../_services/nationality.service';
import { Nationality } from './../../_models/nationality';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nationality',
  templateUrl: './nationality.component.html',
  styleUrls: ['./nationality.component.css']
})
export class NationalityComponent implements OnInit {
  adminPages:string[] = ['author','genre','language','loan','loaner','loanertype','location','material','nationality','publisher','title'];
  nationalities:Nationality[] = [];
  currentNationality:Nationality = {nationalityId:0,name:""};
  constructor(private nationalityService: NationalityService) { }


  ngOnInit(): void {
    this.nationalityService.readAllNationalities()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.nationalities = data;
      }

    })
  }
  edit(nationality:Nationality){
    console.log("selected nationality: " + nationality.name);

    this.currentNationality = nationality;
  }

  deleteNationality(){
    if (confirm(`Er du sikker på at du vil slette sproget: ${this.currentNationality.name}?`)) {
      this.nationalityService.deleteNationality(this.currentNationality.nationalityId)
      .subscribe(data => {
        console.log(`Deleted data is: ${data.nationalityId} ${data.name}`);
        this.nationalities = this.nationalities.filter(nationalityObj => nationalityObj.nationalityId != this.currentNationality.nationalityId);
        this.reset();
      })
    }

  }

  saveNationality(){
  if (this.currentNationality.nationalityId <= 0 || this.currentNationality.nationalityId == null) {
      this.nationalityService.createNationality(this.currentNationality)
      .subscribe(data => {
        console.log(`Save created new nationality: ${data.nationalityId} ${data.name}`);
        this.nationalities.push(data);
        this.reset();
      })
    }
    else {
      this.nationalityService.updateNationality(this.currentNationality.nationalityId, this.currentNationality)
      .subscribe(data =>{
        console.log(`Save updated existing nationality: ${data.nationalityId} ${data.name}`);
        let nationalityIndex:number = this.nationalities.findIndex(nationalityObj => nationalityObj.nationalityId == this.currentNationality.nationalityId);
        this.nationalities[nationalityIndex] = data;
        this.reset();
      })
    }

  }

  reset(){
    this.currentNationality = {nationalityId:0, name:""};
  }

}
