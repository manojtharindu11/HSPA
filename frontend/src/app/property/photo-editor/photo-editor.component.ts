import { Component, EventEmitter, Input, Output } from '@angular/core';
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
  @Output() mainPhotoChangeEvent = new EventEmitter<string>();

  constructor(private housingService: HousingService) {}

  setPrimaryPhoto(propertyId: number, photo: Photo) {
    this.housingService
      .setPrimaryPhoto(propertyId, photo.publicId)
      .subscribe(() => {
        this.mainPhotoChange(photo.imageUrl);
        this.property.photos?.forEach((p) => {
          if (p.isPrimary == true) p.isPrimary = false;
          if (p.publicId === photo.publicId) p.isPrimary = true;
        });
      });
  }

  mainPhotoChange(url: string) {
    this.mainPhotoChangeEvent.emit(url);
  }
}
