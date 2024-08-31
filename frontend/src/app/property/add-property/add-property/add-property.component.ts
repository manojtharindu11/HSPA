import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.css']
})
export class AddPropertyComponent {

  constructor(private router:Router) {}

  onBack() {
    this.router.navigate(['/']);
  }
}
