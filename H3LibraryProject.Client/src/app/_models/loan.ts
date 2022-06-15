import { Material } from './material';
import { Loaner } from './loaner';
export interface Loan{
  loanId:number;
  loanerId:number;
  materialId:number;
  loanDate:Date;
  returnDate:Date;
  loaner:LoanLoaner;
  material:LoanMaterial;
  isReturned:boolean;

}

export interface LoanLoaner{
  loanerId:number;
  loanerTypeId:number;
  loanerTypeName:string;
  name:string;
}

export interface LoanMaterial{
  locationId:number;
  materialId:number;
  titleId:number;
  titleName:string

}
