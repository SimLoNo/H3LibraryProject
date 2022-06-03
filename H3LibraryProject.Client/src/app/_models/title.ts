import { Material } from './material';
export interface MaterialTitle{
  titleId:number;
  name:string;
  languageId:number;
  rYear:number;
  pages:number;
  publisherId:number;
 // authorId:number // Er usikker på med det her, title har jo en mange til mange med title.
 genreId:number;
 materials?:Material[];
}
