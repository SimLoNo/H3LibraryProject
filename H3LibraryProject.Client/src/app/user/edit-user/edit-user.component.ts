import { LoanerService } from './../../_services/loaner.service';
import { Loaner } from './../../_models/loaner';
import { Component, OnInit } from '@angular/core';
import { LoanerAuthenticator } from 'src/app/_models/LoanerAuthenticator';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit {

  user:Loaner = {loanerId:0,loanerName:"",loanerTypeId:0,password:""};
  loanerAuthenticator:LoanerAuthenticator = {name:"",password:""};

  constructor(private loanerService:LoanerService) { }

  ngOnInit(): void {
    this.loanerService.readLoanerById(1)
    .subscribe((data) => {
      if (data != null) {
        console.log(data.loanerId, data.loanerName, data.loanerTypeId);

        this.user = data;
      }
    })
  }

  updateUser(){
    console.log(this.user.loanerName, this.loanerAuthenticator.name);

    this.loanerService.updateUserLoaner(this.user,this.loanerAuthenticator)
    .subscribe((data) => {
      console.log(data);

    })
  }

}
