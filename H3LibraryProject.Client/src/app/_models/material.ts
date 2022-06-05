import { LibLocation } from './location';
import { MaterialTitle } from './title';
export interface Material{
  materialId:number;
  titleId:number;
  locationId:number;
  home:boolean;
  bookTitle?:MaterialTitle;
  title:MaterialMaterialTitle;
  location:MaterialLibLocation;

}

export interface MaterialMaterialTitle{
  titleId:number;
  name:String;
  rYear:number;
  pages:number;
}

export interface MaterialLibLocation{
  locationId:number;
  name:string;
}
