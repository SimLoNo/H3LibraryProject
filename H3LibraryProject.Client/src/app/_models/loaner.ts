import { Loan } from './loan';
import { LoanerType } from './loanerType';
export interface Loaner{
  loanerId:number;
  loanerTypeId:number;
  loanerName:string;
  password?:string;
  typeOfLoaner?:LoanerType;
  loans?:Loan[];
}
