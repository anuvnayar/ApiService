import { Component } from '@angular/core';
import {UserDetailsService} from './services/user-details.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'AngularApp';
  users:any;
  constructor (private userdetail:UserDetailsService)
  {
    this.userdetail.users().subscribe((data)=>
    {
      console.warn("data",data);
      this.users=data;
    })
  }
}
