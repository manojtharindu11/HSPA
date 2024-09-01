import { Injectable } from '@angular/core';
import { User } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  addUsers(user: User) {
    // Retrieve the existing users from local storage
    let storedUsers = localStorage.getItem('Users');
    let users:User[] = [];

    // If there are already users in local storage, parse them
    if (storedUsers) {
        users = JSON.parse(storedUsers);
    }

    // Add the new user to the existing array
    users.push(user);

    // Store the updated array back in local storage
    localStorage.setItem('Users', JSON.stringify(users));
}
}
