import { Property } from './../../model/property';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css']
})
export class PropertyDetailComponent implements OnInit {
  public propertyId:number = 0;
  property = new Property()

  constructor(private route:ActivatedRoute, private router:Router,private housingService:HousingService) {}

  ngOnInit(): void {
      this.propertyId = this.route.snapshot.params['id']

      this.route.data.subscribe(
        (data) => {
          this.property = data['prp'];
        }
      )

      // this.housingService.getProperty(this.propertyId).subscribe(
      //   (data)=> {
      //     if (data) {
      //       this.property= data;
      //     }
      //   },
      //   error => {
      //     console.log(error)
      //     this.router.navigate(['/']);
      //   }
      // )
  }
}
