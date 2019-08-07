import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { timingSafeEqual } from 'crypto';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  //values: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
      //this.getValues();
  }

  registerToggle() {
    // console.log('in register toggle with ' + this.registerMode);
    this.registerMode = true; //!this.registerMode;
  }

    /* Raghu: added this method to get observable method
    getValues() {
      this.http.get('http://localhost:5000/api/getall2').subscribe(response => {
        this.values = response;
      }, error => {
        console.log(error);
      });
    }*/

    cancelRegisterMode(registerMode:boolean) {
      this.registerMode = registerMode;
    }

}
