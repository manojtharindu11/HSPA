import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { IProperty } from '../../IProperty.interface';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.css']
})
export class AddPropertyComponent {
  @ViewChild('form') addPropertyForm!: NgForm;
  @ViewChild('staticTabs') staticTabs?: TabsetComponent;

  propertyTypes:Array<string> = ['House','Apartment','Duplex'];
  furnishTypes:Array<string> = ['Fully','Semi','Unfurnished'];

  propertyView: IProperty = {
    Id: 0,
    SellRent: 1,
    Name: '',
    Type: '',
    Price: 0
  }


  constructor(private router:Router) {}

  onBack() {
    this.router.navigate(['/']);
  }

  onSubmit() {
    console.log(this.addPropertyForm.value)
  }

  selectTab(tabId: number) {
    if (this.staticTabs?.tabs[tabId]) {
      this.staticTabs.tabs[tabId].active = true;
    }
  }
}
