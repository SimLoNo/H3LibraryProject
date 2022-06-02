import { Title } from './title';
export interface Language{
  languageId:number;
  name:string;
  titles?:Title[];
}
