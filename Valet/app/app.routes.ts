import { NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { NativeScriptRouterModule } from "nativescript-angular/router";

import {GettingStartedComponent} from './getting-started/getting-started.component';
import {FindCarComponent} from './find-car/find-car.component';
import {FindParkingComponent} from './find-parking/find-parking.component';
import {ParkingComponent} from './parking/parking.component';
import {ParkingReminderComponent} from './parking/reminder/reminder.component';
import {RegisterParkingComponent} from './parking/register/register.component';
import {AvailableParkingComponent} from './parking/available/available.component';
import {DriverOptionsComponent} from './driver-options/driver-options.component';


export const routes = [
    {path: '', component: GettingStartedComponent},
    {path: 'getting-started', component: GettingStartedComponent},
    {path: 'find-car', component: FindCarComponent},
    {path: 'find-parking', component: FindParkingComponent},
    //{path: '', component: FindCarComponent},
    {path: 'driver-options', component: DriverOptionsComponent},    
    {path: 'available-parking', component: AvailableParkingComponent},
    {path: 'parking', component: ParkingComponent},
    {path: 'parking-reminder', component: ParkingReminderComponent},
    {path: 'register-parking', component: RegisterParkingComponent},
];

export const appComponents = [
    GettingStartedComponent,
    FindCarComponent,
    FindParkingComponent,
    ParkingComponent,
    ParkingReminderComponent,
    RegisterParkingComponent,
    DriverOptionsComponent,
    AvailableParkingComponent
];

@NgModule({
    imports: [NativeScriptRouterModule.forRoot(routes)],
    exports: [NativeScriptRouterModule]
})
export class AppRoutingModule {}