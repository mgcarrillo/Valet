import { Component } from "@angular/core";
import {Router} from "@angular/router";
import { ApiService } from '../../framework/api.service'

@Component({
  selector: "register-parking",
  moduleId: module.id,
  templateUrl: "./register.component.html",
  styleUrls: ['./register.component.css']
})
export class RegisterParkingComponent {
  public address: string;
  public spaceCount: string;
  public startHour: string;
  public endHour: string;
  public price: string;

  public acceptCredit: boolean;
  public acceptCash: boolean;
  public coveredParking: boolean;

  public operator: ReigsterParkingOperator = new ReigsterParkingOperator();

  constructor(private apiService: ApiService,
              private router: Router) {

  }
  
  public save(isEvent: boolean) {
    this.operator.EventParking = isEvent;
    this.operator.ParkingGarage = !isEvent;
    this.apiService.post('/parking', this.operator).subscribe(() => this.router.navigate(['./getting-started']));
  }
}

export class ReigsterParkingOperator {
  OperatorName: string;
  Latitude: number;
  Longitude: number;
  Address1: string;
  City: string;
  State: string;
  Zip: string;
  Phone: string;
  WebsiteUrl: string;
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
