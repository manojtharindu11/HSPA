import { ActivatedRoute } from '@angular/router';
import { Component,OnInit } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';
import { IPropertyBase } from 'src/app/model/IPropertyBase';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {
  sellRent = 1;
  properties:IPropertyBase [] = [];

  constructor(private route:ActivatedRoute, private housingService: HousingService) { }

  ngOnInit(): void {
    if (this.route.snapshot.url.toString()) {
      this.sellRent = 2; // Means that we are on the rent-property URL else we are on the base URL
    }
    this.housingService.getAllProperties(this.sellRent).subscribe(
      data=>{
        console.log(data);
        this.properties=data;
      },
      error=>{
        console.log('httperror:');
        console.log(error);
      }
    )
    // this.http.get('data/properties.json').subscribe
  }
}
