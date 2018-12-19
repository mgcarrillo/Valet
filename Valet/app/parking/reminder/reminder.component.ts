import { Component } from "@angular/core";
import { getCurrentLocation } from "nativescript-geolocation";
import { Accuracy } from 'ui/enums'
import dialogs = require("ui/dialogs");
import applicationSettings = require("application-settings");

import {ApiService} from './../../framework/api.service'

@Component({
  selector: "parking-reminder",
  moduleId: module.id,
  templateUrl: "./reminder.component.html" ,
  styleUrls: ["./reminder.component.css"]
})
export class ParkingReminderComponent {
  public hours:string= "00";
  public minutes:string= "00";
  public seconds: string = "00";

  public constructor(private apiService: ApiService) {

  }

  public setReminder(){
    this.saveParkingSpot();
  }

  private saveParkingSpot() {
    getCurrentLocation({ desiredAccuracy: Accuracy.high, updateDistance: 0.1, maximumAge: 5000, timeout: 20000 }).
      then((loc) => {
        if (loc) {
          localStorage.setItem('lat', loc.latitude + '');
          localStorage.setItem('long', loc.longitude + '');
          console.log(`${this.hours}:${this.minutes}:${this.seconds}`);
          this.apiService.put('/Driver', {
            Expires: this.getExpireTime(),
            DeviceId: applicationSettings.getString('deviceId').trim()
          }).subscribe();
          dialogs.alert("Your parking spot has been saved!").then(()=>{});
        }
      });
  }


  private getUnixTime(date) {
    return date.getTime()/1000|0;
  }

  public getExpireTime(): number {
    
    let h = +this.hours;
    let m = +this.minutes;
    let s = +this.seconds;

    let date = new Date();
    date.setHours(date.getHours() + h);
    date.setMinutes(date.getMinutes() + m);
    date.setSeconds(date.getHours() + s);

    console.log(date);
    console.log(this.getUnixTime(date));

    return this.getUnixTime(date)
  }

}
