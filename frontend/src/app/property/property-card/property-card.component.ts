import { Component, Input } from "@angular/core";
import { IPropertyBase } from "src/app/model/iPropertyBase";

@Component({
    selector: 'app-property-card',
    // template: '<h1>I am a card</h1>',
    templateUrl:'property-card.component.html',
    // styles: ['h1 {font-weight:normal;}']
    styleUrls: ['property-card.component.css']
})
export class PropertyCardComponent {
@Input() hideIcon?: boolean
@Input() property : IPropertyBase = {
    Id: 0,
    SellRent: 1,
    Name: "",
    PType: "",
    Price: 0,
    FType: "",
    BHK: 0,
    BuiltArea: 0,
    City: "",
    RTM: 0
};
}