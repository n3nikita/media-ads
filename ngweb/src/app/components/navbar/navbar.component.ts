import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, NavigationStart, NavigationError } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/app/models/user';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  isLoginPage: boolean;

  get isLoggedIn(): boolean {
    return this.authService.isLoggedIn;
  }

  get userInfo(): User {
    return this.authService.getUserInfo();
  }

  constructor(private router: Router, private authService: AuthService) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        // Show loading indicator
      }

      if (event instanceof NavigationEnd) {
        if(event.url == '/login')
          this.isLoginPage = true;
        else
          this.isLoginPage = false;
      }

      if (event instanceof NavigationError) {
        // Hide loading indicator

        // Present error to user
        console.log(event.error);
      }
    });
  }

  logOut(){
    this.authService.logOut();
    this.router.navigate(['/']);
  }

  ngOnInit() {
  }

}
