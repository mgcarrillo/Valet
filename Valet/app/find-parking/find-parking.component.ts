import { Component, ViewChild, ElementRef } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Marker, Position } from 'nativescript-google-maps-sdk';
import { Accuracy } from 'ui/enums';

@Component({
  selector: "find-parking",
  moduleId: module.id,
  templateUrl: "./find-parking.component.html"
})
export class FindParkingComponent {
  public latitude: number;
  public longitude: number;
  public zoom: number = 15;
  public bearing: number = 0;
  public tilt: number = 0;

  @ViewChild("MapView") mapView: ElementRef;

  constructor(private router: ActivatedRoute) {

  }

  ngOnInit() {
    let parameters = this.router.snapshot.params;

    this.latitude = parameters['latitude'];
    this.longitude = parameters['longitude'];
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
