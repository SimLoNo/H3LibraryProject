import { Material } from './material';
import { Loaner } from './loaner';
export interface Loan{
  loanId:number;
  loanerId:number;
  materialId:number;
  loanDate:Date;
  returnDate:Date;
  loanerLoaning?:Loaner;
  materialLoaned?:Material;

}
