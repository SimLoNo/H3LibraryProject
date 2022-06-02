import { Title } from './title';
export interface Genre{
  genreId:number;
  name:string;
  leasePeriod:number;
  titles?:Title[];
}
