import { Material } from './material';
export interface Location{
  locationId:number;
  name:string;
  materials?:Material[];
}
