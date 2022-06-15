import { Material } from './material';
export interface LibLocation{
  locationId:number;
  name:string;
  materials?:Material[];
}
