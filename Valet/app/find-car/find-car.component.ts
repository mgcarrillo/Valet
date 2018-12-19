import { Component, ViewChild, ElementRef } from "@angular/core";
import { Marker, Position } from 'nativescript-google-maps-sdk';
import { Accuracy } from 'ui/enums';
require('nativescript-localstorage');

@Component({
  selector: "find-car",
  moduleId: module.id,
  templateUrl: "./find-car.component.html"
})
export class FindCarComponent {
  public latitude: number = 40.5761634;
  public longitude: number = -111.89270620000002;
  public zoom: number = 15;
  public bearing: number = 0;
  public tilt: number = 0;

  @ViewChild("MapView") mapView: ElementRef;

  ngOnInit() {
    //protect against undefined later
    this.latitude = +localStorage.getItem('lat');
    this.longitude = +localStorage.getItem('long');
  }

  public onMapReady(e) {
    let marks: { latitude: number, longitude: number }[] = [

      {
        latitude: this.latitude,
        longitude: this.longitude
      }
    ];

    for (let i = 0; i < marks.length; i++) {
      let marker = new Marker();
      marker.position = Position.positionFromLatLng(marks[i].latitude, marks[i].longitude);
      marker.userData = { index: i + 1 };
      e.object.addMarker(marker);
    }

  }
}
