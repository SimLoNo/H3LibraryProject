import { MaterialTitle } from './title';
export interface Language{
  languageId:number;
  name:string;
  titles?:MaterialTitle[];
}
