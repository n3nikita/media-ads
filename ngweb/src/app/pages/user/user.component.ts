import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    //https://angular.io/guide/router#activated-route-in-action

    let username = this.route.snapshot.paramMap.get('username');
    console.log(username);
  }

}
