import { Component, OnInit } from "@angular/core";
import {  ApiService } from './framework/api.service'
import applicationSettings = require("application-settings");

@Component({
  selector: "my-app",
  templateUrl: "./app.component.html" 
})
export class AppComponent implements OnInit{
  // Your TypeScript logic goes here
  constructor(private apiService: ApiService){ 

  }

  public ngOnInit(){

  }
}
