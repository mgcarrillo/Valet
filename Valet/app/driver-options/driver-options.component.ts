import { Component } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "driver-options",
  moduleId: module.id,
  templateUrl: "./driver-options.component.html" 
})
export class DriverOptionsComponent {
  constructor(private router: Router) {

  }

  public navigateToFindParking(){
    this.router.navigate(['./available-parking']);
  }

  public navigateToFindMyCar(){
    this.router.navigate(['./find-car']);
  }

  public navigateToParkCar(){
    this.router.navigate(['./parking']);
  }
}
