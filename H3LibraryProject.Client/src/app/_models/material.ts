import { Author } from './author';
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
  authors:Author[];
}

export interface MaterialLibLocation{
  locationId:number;
  name:string;
}
