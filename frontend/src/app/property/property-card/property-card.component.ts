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
    id: 0,
    sellRent: 1,
    name: "",
    propertyType: "",
    price: 0,
    furnishingType: "",
    bhk: 0,
    builtArea: 0,
    city: "",
    readyToMove: false
};
}