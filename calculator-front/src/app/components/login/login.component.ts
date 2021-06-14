import { Component,  } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent   {

  invalidLogin!: boolean;

  constructor(
    private router: Router,
    private route: ActivatedRoute) { }

    submit(name:any): void {
      this.router.navigate(  ['/calculate']);
      };

     
 
}