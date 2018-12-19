import { NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { NativeScriptModule } from "nativescript-angular/nativescript.module";
import { NativeScriptHttpModule } from "nativescript-angular/http";
import { NativeScriptFormsModule } from "nativescript-angular/forms";
import { NativeScriptRouterModule } from "nativescript-angular/router";
import {ApiService} from './framework/api.service';

import { AppComponent } from "./app.component";
import {routes, appComponents, AppRoutingModule} from './app.routes';

@NgModule({
  declarations: [AppComponent, ...appComponents],
  bootstrap: [AppComponent],
  imports: [NativeScriptModule,
  NativeScriptFormsModule,
  NativeScriptHttpModule,
  AppRoutingModule
  ],
  providers: [ApiService],
  schemas: [NO_ERRORS_SCHEMA],
})
export class AppModule {}
