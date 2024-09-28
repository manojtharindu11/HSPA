import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { UserForLogin } from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = environment.baseUrl
  constructor(private http:HttpClient) { }

  authUser(user:UserForLogin) {
    return this.http.post(this.baseUrl+"/account/login",user)
    // let userArray = [];
    // const users = localStorage.getItem('Users')
    // if (users) {
    //   userArray = JSON.parse(users)
    // }
    // return userArray.find((u:any) => u.userName === user.userName && u.password === user.password);
  }
}
