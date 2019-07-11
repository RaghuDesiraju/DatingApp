import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-value',
  templateUrl: './value.component.html',
  styleUrls: ['./value.component.css']
})
export class ValueComponent implements OnInit {
// Raghu: added property. values has no datatype specified. inject http client to constructor
  values: any;
  // constructor() { }
  constructor(private http: HttpClient) {}

  // ngOnInit() {
  // }

  ngOnInit() {
    this.getValues();
  }

  // Raghu: added this method to get observable method
  getValues() {
    this.http.get('http://localhost:5000/api/getall2').subscribe(response => {
      this.values = response;
    }, error => {
      console.log(error);
    });
  }
}
