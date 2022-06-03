import { LoanerType } from 'src/app/_models/loanerType';
import { LoanerTypeService } from './../../_services/loaner-type.service';
import { Component, OnInit } from '@angular/core';
import { Loaner } from 'src/app/_models/loaner';
import { LoanerService } from 'src/app/_services/loaner.service';

@Component({
  selector: 'app-loaner',
  templateUrl: './loaner.component.html',
  styleUrls: ['./loaner.component.css']
})
export class LoanerComponent implements OnInit {
  adminPages:string[] = ['author','genre','language','loan','loaner','loanertype','location','material','nationality','publisher','title'];
  loaners:Loaner[] = [];
  loanerTypes:LoanerType[] = [];
  currentLoaner:Loaner = {loanerId:0,loanerName:"",password:"",loanerTypeId:0};
  constructor(private loanerService: LoanerService, private loanerTypeService:LoanerTypeService) { }


  ngOnInit(): void {
    this.loanerService.readAllLoaners()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        data.forEach(element => {
          console.log("loaner name: " + element.loanerName);

        });
        this.loaners = data;
      }

    });

    this.loanerTypeService.readAllLoanerTypes()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.loanerTypes = data;
      }

    })
  }
  edit(loaner:Loaner){
    console.log("selected loaner: " + loaner.loanerName);

    this.currentLoaner = loaner;
  }

  deleteLoaner(){
    if (confirm(`Er du sikker på at du vil slette sproget: ${this.currentLoaner.loanerName}?`)) {
      this.loanerService.deleteLoaner(this.currentLoaner.loanerId)
      .subscribe(data => {
        console.log(`Deleted data is: ${data.loanerId} ${data.loanerName}`);
        this.loaners = this.loaners.filter(loanerObj => loanerObj.loanerId != this.currentLoaner.loanerId);
        this.reset();
      })
    }

  }

  saveLoaner(){
    console.log(`Saved loaner: id: ${this.currentLoaner.loanerId}, loanerTypeId: ${this.currentLoaner.loanerTypeId}, name: ${this.currentLoaner.loanerName}, password: ${this.currentLoaner.password}`);

  if (this.currentLoaner.loanerId <= 0 || this.currentLoaner.loanerId == null) {
      this.loanerService.createLoaner(this.currentLoaner)
      .subscribe(data => {
        console.log(`Save created new loaner: ${data.loanerId} ${data.loanerName}`);
        this.loaners.push(data);
        this.reset();
      })
    }
    else {
      this.loanerService.updateLoaner(this.currentLoaner.loanerId, this.currentLoaner)
      .subscribe(data =>{
        console.log(`Save updated existing loaner: ${data.loanerId} ${data.loanerName}`);
        let loanerIndex:number = this.loaners.findIndex(loanerObj => loanerObj.loanerId == this.currentLoaner.loanerId);
        this.loaners[loanerIndex] = data;
        this.reset();
      })
    }

  }

  reset(){
    this.currentLoaner = {loanerId:0, loanerName:"",password:"",loanerTypeId:0};
  }
}
