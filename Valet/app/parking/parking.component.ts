import { Component } from "@angular/core";
import { Router } from '@angular/router';
import { getCurrentLocation } from "nativescript-geolocation";
import { Accuracy } from 'ui/enums'
import dialogs = require("ui/dialogs");
require('nativescript-localstorage');

@Component({
  selector: "parking",
  templateUrl: "./parking/parking.component.html"
})
export class ParkingComponent {
  // Your TypeScript logic goes here

  constructor(private router: Router) {

  }

  public saveParkingSpot() {
    getCurrentLocation({ desiredAccuracy: Accuracy.high, updateDistance: 0.1, maximumAge: 5000, timeout: 20000 }).
      then((loc) => {
        if (loc) {
          localStorage.setItem('lat', loc.latitude + '');
          localStorage.setItem('long', loc.longitude + '');

          dialogs.alert("Your parking spot has been saved!").then(()=>{});
        }
      });

            
    console.log("Saving the parking spot");
  }

  public navigateToTimedParking() {
    this.router.navigate(['./parking-reminder']);
  }
}
