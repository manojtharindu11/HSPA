import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent {
  loggedInUser: string = '';

  loggedIn() {
    this.loggedInUser = localStorage.getItem('token') || ''
    return this.loggedInUser
  }

  onLogout() {
    localStorage.removeItem('token');
  }
}
