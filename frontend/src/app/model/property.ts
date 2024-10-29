import { IPropertyBase } from "./iPropertyBase";
import { Photo } from "./photo.ts";

export class Property implements IPropertyBase {
  id: number = 0;
  sellRent: number = 0;
  name: string = '';
  propertyType: string = '';
  propertyTypeId:number = 0;
  bhk: number = 0;
  furnishingType: string = '';
  furnishingTypeId:number = 0;
  price: number = 0;
  builtArea: number = 0;
  carpetArea?: number;
  address: string = '';
  address2?: string;
  city: string = '';
  cityId:number = 0;
  floorNo?: string;
  totalFloors?: string;
  readyToMove: boolean = false;
  age?: string;
  mainEntrance?: string;
  security?: number;
  gated?: boolean;
  maintenance?: number;
  estPossessionOn?: string;
  photo?: string;
  description?: string;
  photos?: Photo[];
}