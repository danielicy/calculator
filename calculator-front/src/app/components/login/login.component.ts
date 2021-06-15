import { Component,  } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { LocalStorageService } from 'src/app/core/services/storage/storage.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent   {

  invalidLogin!: boolean;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private storage: LocalStorageService) { }

    submit(name:any): void {
      this.storage.setItem("user",name.form.value.contact.Name);       
      this.router.navigate(  ['/calculate']);
      };

     
 
}