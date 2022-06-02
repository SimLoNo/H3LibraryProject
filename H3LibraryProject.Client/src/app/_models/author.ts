import { Nationality } from './nationality';
import { Title } from './title';
export interface Author{
  authorId:number;
  lName:string;
  fName:string;
  mName:string;
  bYear:number;
  dYear:number;
  nationalityId:number;
  titles?:Title[];
  nationality:Nationality;

}
