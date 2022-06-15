import { Loan } from './../../_models/loan';
import { LoanService } from './../../_services/loan.service';
import { LoanerService } from './../../_services/loaner.service';
import { Component, OnInit } from '@angular/core';
import { Loaner } from 'src/app/_models/loaner';

@Component({
  selector: 'app-account-page',
  templateUrl: './account-page.component.html',
  styleUrls: ['./account-page.component.css']
})
export class AccountPageComponent implements OnInit {
  loggedLoanerId:number = 1;
  loaner:Loaner = {loanerId:0,loanerName:"",loanerTypeId:0};
  inactiveLoans:Loan[] = [];
  activeLoans:Loan[] = []
  showHistory:boolean = false;

  constructor(private loanerService:LoanerService, private loanService:LoanService) { }

  ngOnInit(): void {
    this.loanerService.readLoanerById(this.loggedLoanerId)
    .subscribe((data) =>{
      this.loaner = data;
    })
    this.loanService.readLoanByLoanerId(this.loggedLoanerId)
    .subscribe((data) => {
      data.forEach(l => {
        if (l.isReturned == true) {
          this.inactiveLoans.push(l);
        }
        else{
          this.activeLoans.push(l);
        }
      })
    })
  }

  extendLoan(loan:Loan){
    this.loanService.userLoan(loan.loanId, loan.materialId, 2)
    .subscribe((data) => {
      if (data != null) {
        let loanIndex:number = this.activeLoans.findIndex(l => l.loanId == data.loanId);
        if (loanIndex != null) {
          this.activeLoans[loanIndex] = data;
        }
      }
    })
  }
  returnLoan(loan:Loan){
    this.loanService.userLoan(loan.loanId, loan.materialId, 3)
    .subscribe((data) => {
      if (data != null) {
        let returnedLoanIndex:number = this.activeLoans.findIndex(l => l.loanId == data.loanId);
        this.inactiveLoans.push(this.activeLoans[returnedLoanIndex]);
        this.activeLoans = this.activeLoans.filter(l => l.loanId != data.loanId);
      }
    })
  }

}
