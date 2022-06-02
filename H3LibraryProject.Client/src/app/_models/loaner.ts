import { Loan } from './loan';
import { LoanerType } from './loanerType';
export interface Loaner{
  loanerId:number;
  loanerTypeId:number;
  name:string;
  typeOfLoaner?:LoanerType;
  loans?:Loan[];
}
