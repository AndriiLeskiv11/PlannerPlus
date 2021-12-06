import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { async } from '@angular/core/testing';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit
{
  cols!: any[];
  masters!: any[];
  /**
   *
   */
  constructor(private httpclient:HttpClient) {
    
  }
  ngOnInit(): void {
    this.httpclient.get("https://localhost:5001/api/masters").subscribe(r => {
      this.masters = r as any[];
    });
    this.cols = [
      { field: 'name', header: 'Name'},
      { field: 'surname', header: 'surname'},
      { field: 'mail', header: 'Mail'},
    ]
  
  }
 
}
