import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "getting-started",
  moduleId: module.id,
  templateUrl: "./getting-started.component.html" 
})
export class GettingStartedComponent {
  // Your TypeScript logic goes here

  constructor(private router: Router) {

  }

  public navigateToOperator(){
    this.router.navigate(['./register-parking']);
  }

  public navigateToDriver(){
    this.router.navigate(['./driver-options']);
  }
}
