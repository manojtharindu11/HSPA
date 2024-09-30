import { IPropertyBase } from "./iPropertyBase";

export class Property implements IPropertyBase {
  id: number = 0;
  sellRent: number = 0;
  name: string = '';
  propertyType: string = '';
  bhk: number = 0;
  furnishingType: string = '';
  price: number = 0;
  builtArea: number = 0;
  carpetArea?: number;
  address: string = '';
  address2?: string;
  city: string = '';
  floorNo?: string;
  totalFloor?: string;
  readyToMove: number = 0;
  age?: string;
  mainEntrance?: string;
  security?: number;
  gated?: boolean;
  maintenance?: number;
  estPossessionOn?: Date;
  image?: string;
  description?: string;
}