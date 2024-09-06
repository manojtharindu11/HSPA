import { IPropertyBase } from "./IPropertyBase";

export class Property implements IPropertyBase {
  Id: number = 0;
  SellRent: number = 0;
  Name: string = '';
  PType: string = '';
  BHK: number = 0;
  FType: string = '';
  Price: number = 0;
  BuiltArea: number = 0;
  CarpetArea?: number;
  Address: string = '';
  Address2?: string;
  City: string = '';
  FloorNo?: string;
  TotalFloor?: string;
  RTM: number = 0;
  AOP?: string;
  MainEntrance?: string;
  Security?: number;
  Gated?: number;
  Maintenance?: number;
  Possession?: string;
  Image?: string;
  Description?: string;
  PostedOn: string = '';
  PostedBy: number = 0;
}