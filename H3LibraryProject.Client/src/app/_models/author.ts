import { Nationality } from './nationality';
import { MaterialTitle } from './title';
export interface Author{
  authorId:number;
  lName:string;
  fName:string;
  mName?:string;
  bYear:number;
  dYear:number;
  nationalityId:number;
  titles?:MaterialTitle[];
  nationality?:Nationality;

}
