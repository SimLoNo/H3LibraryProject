import { Component, OnInit } from '@angular/core';
import { LoanerType } from 'src/app/_models/loanerType';
import { LoanerTypeService } from 'src/app/_services/loaner-type.service';

@Component({
  selector: 'app-loaner-type',
  templateUrl: './loaner-type.component.html',
  styleUrls: ['./loaner-type.component.css']
})
export class LoanerTypeComponent implements OnInit {

  adminPages:string[] = ['author','genre','language','loan','loaner','loanertype','location','material','nationality','publisher','title'];
  loanerTypes:LoanerType[] = [];
  currentLoanerType:LoanerType = {loanerTypeId:0,name:""};
  constructor(private loanerTypeService:LoanerTypeService){}


  ngOnInit(): void {
    this.loanerTypeService.readAllLoanerTypes()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.loanerTypes = data;
      }

    })
  }
  edit(LoanerType:LoanerType){
    console.log("selected LoanerType: " + LoanerType.name);

    this.currentLoanerType = LoanerType;
  }

  deleteLoanerType(){
    if (confirm(`Er du sikker på at du vil slette loanerTypen: ${this.currentLoanerType.name}?`)) {
      this.loanerTypeService.deleteLoanerType(this.currentLoanerType.loanerTypeId)
      .subscribe(data => {
        console.log(`Deleted data is: ${data.loanerTypeId} ${data.name}`);
        this.loanerTypes = this.loanerTypes.filter(loanerTypeObj => loanerTypeObj.loanerTypeId != this.currentLoanerType.loanerTypeId);
        this.reset();
      })
    }

  }

  saveLoanerType(){
  if (this.currentLoanerType.loanerTypeId <= 0 || this.currentLoanerType.loanerTypeId == null) {
      this.loanerTypeService.createLoanerType(this.currentLoanerType)
      .subscribe(data => {
        console.log(`Save created new LoanerType: ${data.loanerTypeId} ${data.name}`);
        this.loanerTypes.push(data);
        this.reset();
      })
    }
    else {
      this.loanerTypeService.updateLoanerType(this.currentLoanerType.loanerTypeId, this.currentLoanerType)
      .subscribe(data =>{
        console.log(`Save updated existing LoanerType: ${data.loanerTypeId} ${data.name}`);
        let LoanerTypeIndex:number = this.loanerTypes.findIndex(loanerTypeObj => loanerTypeObj.loanerTypeId == this.currentLoanerType.loanerTypeId);
        this.loanerTypes[LoanerTypeIndex] = data;
        this.reset();
      })
    }

  }

  reset(){
    this.currentLoanerType = {loanerTypeId:0, name:""};
  }
}
