import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { AuthService } from 'src/app/services/auth.service';
import { Credentials } from 'src/app/models/credentials';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  });
  invalidCredentials = false;

  constructor(private titleService: Title,
              private authService: AuthService,
              private router: Router) { }

  ngOnInit() {
    this.titleService.setTitle('Логин | Media Ads');
  }

  login(){
    let creds = this.loginForm.value; // TODO: check if form valid
    this.authService.authorize(creds).subscribe(
      (data: string) => {
        console.log(data);

        if (data) {
          this.authService.setToken(data);
          this.router.navigate(['/']);
        }

        this.invalidCredentials = false;
      },
      err => {
        if(err.status == 401)
          this.invalidCredentials = true;
      }
    );
  }

}
