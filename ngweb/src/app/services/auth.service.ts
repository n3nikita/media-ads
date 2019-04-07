import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Credentials } from '../models/credentials';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  jwtHelper: JwtHelperService;

  private url = "http://localhost:63472/api/user";

  constructor(private http: HttpClient) {
    this.jwtHelper = new JwtHelperService();
  }

  get isLoggedIn(): boolean {
    return !this.jwtHelper.isTokenExpired();
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
    return this.jwtHelper.tokenGetter();
  }
}
