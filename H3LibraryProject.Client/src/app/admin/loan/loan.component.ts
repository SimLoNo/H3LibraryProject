import { MaterialService } from './../../_services/material.service';
import { LoanService } from './../../_services/loan.service';
import { Component, OnInit } from '@angular/core';
import { dateInputsHaveChanged } from '@angular/material/datepicker/datepicker-input-base';
import { Loan } from 'src/app/_models/loan';
import { LoanerService } from 'src/app/_services/loaner.service';
import { Loaner } from 'src/app/_models/loaner';
import { Material } from 'src/app/_models/material';

@Component({
  selector: 'app-loan',
  templateUrl: './loan.component.html',
  styleUrls: ['./loan.component.css']
})
export class LoanComponent implements OnInit {
  adminPages:string[] = ['author','genre','language','loan','loaner','loanertype','location','material','nationality','publisher','title'];
  loans:Loan[] = [];
  loaners:Loaner[] = [];
  materials:Material[] = [];
  currentLoan:Loan = {loanId:0,loanerId:0,materialId:0,loanDate:new Date(),returnDate:new Date(),loaner:{loanerId:0,loanerTypeId:0,loanerTypeName:"",name:""},material:{materialId:0,titleId:0,locationId:0,titleName:""}};
  constructor(private loanerService: LoanerService, private loanService:LoanService, private materialService:MaterialService) { }


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

    this.loanService.readAllLoans()
    .subscribe((data) => {
      console.log(data);
      data.forEach(l => {
        console.log(`Loan include: ${l.loanId} ${l.loaner.name} ${l.material.titleName}`);

      })
      if (data != null) {
        this.loans = data;
      }

    })

    this.materialService.readAllMaterials()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.materials = data;
      }

    })
  }
  edit(loan:Loan){

    this.currentLoan = loan;
  }

  deleteLoan(){
    if (confirm(`Er du sikker på at du vil slette lånet: ${this.currentLoan.loanId} ${this.currentLoan.loaner.name} ${this.currentLoan.material.titleName}?`)) {
      this.loanService.deleteLoan(this.currentLoan.loanId)
      .subscribe(data => {
        this.loans = this.loans.filter(loansObj => loansObj.loanId != this.currentLoan.loanId);
        this.reset();
      })
    }

  }

  saveLoan(){
  if (this.currentLoan.loanId <= 0 || this.currentLoan.loanId == null) {
      this.loanService.createLoan(this.currentLoan)
      .subscribe(data => {
        this.loans.push(data);
        this.reset();
      })
    }
    else {
      this.loanService.updateLoan(this.currentLoan.loanId, this.currentLoan)
      .subscribe(data =>{
        let loanIndex:number = this.loans.findIndex(loanObj => loanObj.loanId == this.currentLoan.loanId);
        this.loans[loanIndex] = data;
        this.reset();
      })
    }

  }

  reset(){
    this.currentLoan = {loanId:0,loanerId:0,materialId:0,loanDate:new Date(),returnDate:new Date(),loaner:{loanerId:0,loanerTypeId:0,loanerTypeName:"",name:""},material:{materialId:0,titleId:0,locationId:0,titleName:""}};
  }

}
