import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  authUser(user:any) {
    let userArray = [];
    const users = localStorage.getItem('Users')
    if (users) {
      userArray = JSON.parse(users)
    }
    return userArray.find((u:any) => u.userName === user.userName && u.password === user.password);
  }
}
