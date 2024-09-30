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
  CarpetArea?: number;
  Address: string = '';
  Address2?: string;
  city: string = '';
  FloorNo?: string;
  TotalFloor?: string;
  readyToMove: number = 0;
  AOP?: string;
  MainEntrance?: string;
  Security?: number;
  Gated?: number;
  Maintenance?: number;
  Possession?: string;
  image?: string;
  Description?: string;
  PostedOn: string = '';
  PostedBy: number = 0;
}