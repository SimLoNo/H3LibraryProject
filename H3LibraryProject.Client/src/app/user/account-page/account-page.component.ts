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
  activeLoans:Loan[] = []

  constructor(private loanerService:LoanerService, private loanService:LoanService) { }

  ngOnInit(): void {
    this.loanerService.readLoanerById(this.loggedLoanerId)
    .subscribe((data) =>{
      this.loaner = data;
    })
    this.loanService.readLoanByLoanerId(this.loggedLoanerId)
    .subscribe((data) => {
      this.activeLoans = data.filter(l => l.isReturned == false)
    })
  }

}
