import { Property } from './../../model/property';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {
  NgxGalleryAnimation,
  NgxGalleryImage,
  NgxGalleryOptions,
} from '@kolkov/ngx-gallery';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css'],
})
export class PropertyDetailComponent implements OnInit {
  public propertyId: number = 0;
  public mainPhotoUrl: string = '';
  property = new Property();
  galleryOptions: NgxGalleryOptions[] = [];
  galleryImages: NgxGalleryImage[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private housingService: HousingService
  ) {}

  ngOnInit(): void {
    this.propertyId = this.route.snapshot.params['id'];

    this.route.data.subscribe((data) => {
      this.property = data['prp'];
      // console.log(this.property)
    });

    if (this.property.estPossessionOn) {
      this.property.age = this.housingService.getPropertyAge(
        this.property.estPossessionOn
      );
    } else {
      this.property.age = undefined; // or some default value if needed
    }

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
    this.galleryOptions = [
      {
        width: '100%',
        height: '465px',
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
      },
    ];

    this.galleryImages = this.getPropertyPhotos();
  }

  getPropertyPhotos(): NgxGalleryImage[] {
    const photoUrls: NgxGalleryImage[] = [];

    for (const photo of this.property.photos!) {
      if (photo.isPrimary) this.mainPhotoUrl = photo.imageUrl;
      else {
        photoUrls.push({
          small: photo.imageUrl,
          medium: photo.imageUrl,
          big: photo.imageUrl,
        });
      }
    }

    return photoUrls;
  }

  changePrimaryPhoto(mainPhotoUrl: string) {
    this.mainPhotoUrl = mainPhotoUrl;
  }
}
