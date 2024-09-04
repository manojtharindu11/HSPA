export interface IPropertyBase {
    Id: number;
    SellRent: 1 | 2;
    Name: string;
    PType: string;
    FType: string;
    Price: number;
    BHK:number;
    BuildUPArea:number;
    City:string;
    RTM:number;
    Image?: string;
}