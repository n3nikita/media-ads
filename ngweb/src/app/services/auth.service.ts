import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Credentials } from '../models/credentials';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  jwtHelper: JwtHelperService;

  private url = "http://localhost:63472/api/user";

  // TODO: redirect the URL after loggin in
  redirectUrl: string;

  constructor(private http: HttpClient) {
    this.jwtHelper = new JwtHelperService();
  }

  get isLoggedIn(): boolean {
    let token = this.getToken();

    return !this.jwtHelper.isTokenExpired(token);
  }

  authorize(credentials: Credentials){
    return this.http.post(this.url + '/login', credentials);
  }

  logOut() {
    localStorage.removeItem('username');
    localStorage.removeItem('token');
    localStorage.removeItem('role');
  }

  setToken(token: string){
    let decodedToken = this.jwtHelper.decodeToken(token);
    console.log('Decoded token', decodedToken);
    localStorage.setItem('username', decodedToken.name);
    localStorage.setItem('role', decodedToken.role);
    localStorage.setItem('token', token);
  }

  getToken(): string {
    // TODO: tokenGetter doesn't work!!!
    //return this.jwtHelper.tokenGetter();

    // fix
    return localStorage.getItem('token');
  }

  getUserInfo() {
    let user = { username: localStorage.getItem('username'), role: localStorage.getItem('role') } as User;
    // TODO: get user from server
    return user;
  }
}
