import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd, NavigationStart, NavigationError } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  isLoginPage: boolean;

  constructor(private router: Router) {
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

  ngOnInit() {
  }

}
