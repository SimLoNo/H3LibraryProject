import { Title } from './title';
export interface Material{
  materialId:number;
  titleId:number;
  locationId:number;
  home:boolean;
  bookTitle?:Title;

}
