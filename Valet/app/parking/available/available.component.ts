import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { getCurrentLocation } from "nativescript-geolocation";
import { Accuracy } from 'ui/enums'
import { BehaviorSubject } from "rxjs/Rx";
import { Marker, Position } from 'nativescript-google-maps-sdk';

import { ApiService } from './../../framework/api.service';

export interface ParkingInfo {
  OperatorName: string;
  Latitude: number;
  Longitude: number;
  Address1: string;
  City: string;
  State: string;
  Zip: string;
  Phone?: any;
  WebsiteUrl?: any;
  NumberOfSpaces: number;
  InitialFee: number;
  InitialHours: number;
  SubsequentHourlyFee: number;
  AcceptsCash: boolean;
  AcceptsCredit: boolean;
  CoveredParking: boolean;
  Open24Hours: boolean;
  HourOpen: number;
  HourClosed: number;
  EventParking: boolean;
  ParkingGarage: boolean;
  Distance: number;
}

@Component({
  selector: "available-parking",
  moduleId: module.id,
  templateUrl: "./available.component.html"
})
export class AvailableParkingComponent implements OnInit {
  // Your TypeScript logic goes here
  public latitude:number;
  public longitude:number;
  public zoom: number = 15;
  public bearing: number = 0;
  public tilt: number = 0;
  public parkingInfos = new BehaviorSubject<ParkingInfo[]>([]);

  constructor(private router: Router, private apiService: ApiService) {

  }

  public ngOnInit() {
    getCurrentLocation({ desiredAccuracy: Accuracy.high, updateDistance: 0.1, maximumAge: 5000, timeout: 20000 }).
      then((loc) => {
        if (loc) {
          this.latitude = loc.latitude;
          this.longitude = loc.longitude;
          console.log(loc.latitude);
          console.log(loc.longitude);
          this.apiService
            .get<ParkingInfo[]>(`/Parking?latitude=${loc.latitude}&longitude=${loc.longitude}&radius=5`)
            .subscribe((parking) => {
              this.parkingInfos.next(parking);
            });
        }
      }, function (e) {
        console.log("Error: " + e.message);
      });
  }

  public onMapReady(e) {
    this.parkingInfos.subscribe((parking) => {
      let marks: { latitude: number, longitude: number }[] = parking.map(p => {
        return {
          latitude: p.Latitude,
          longitude: p.Longitude
        }
      });

      for (let i = 0; i < marks.length; i++) {
        let marker = new Marker();
        marker.position = Position.positionFromLatLng(marks[i].latitude, marks[i].longitude);
        marker.userData = { index: i + 1 };
        e.object.addMarker(marker);
      }
    })
  }
}
