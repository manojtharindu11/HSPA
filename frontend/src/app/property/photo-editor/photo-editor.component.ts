import { Component, Input } from '@angular/core';
import { Photo } from 'src/app/model/photo.ts';
import { Property } from 'src/app/model/property';
import { HousingService } from 'src/app/services/housing.service';

@Component({
  selector: 'app-photo-editor',
  templateUrl: './photo-editor.component.html',
  styleUrls: ['./photo-editor.component.css'],
})
export class PhotoEditorComponent {
  @Input() property!: Property;

  constructor(private housingService: HousingService) {}

  setPrimaryPhoto(propertyId: number, photo: Photo) {
    this.housingService.setPrimaryPhoto(propertyId, photo.publicId).subscribe({
      next: (res: any) => {
        console.log(res);
      },
      error: (err: any) => {
        console.log(err);
      },
    });
  }
}
