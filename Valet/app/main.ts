import { platformNativeScriptDynamic } from "nativescript-angular/platform";
import {registerElement} from "nativescript-angular/element-registry";
import * as platform from "platform";
import applicationSettings = require("application-settings");
import * as app from 'application';
import {alert} from 'ui/dialogs';

import { AppModule } from "./app.module";



registerElement("MapView", () => require("nativescript-google-maps-sdk").MapView );

const settings = { 
    senderID: '152664401245' 
}

app.on(app.launchEvent, (args: app.ApplicationEventData) => {
    if (args.android) {
        const pushPlugin = require("nativescript-push-notifications");
        pushPlugin.register(settings, (token) => {
            applicationSettings.setString("deviceId", token.trim());
            console.log('Device registered successfully : ' + token);
        }, (error) => { console.log(error); });
    }
});

app.on(app.resumeEvent, (args: app.ApplicationEventData) => {
    if (args.android) {
        const pushPlugin = require("nativescript-push-notifications");
        pushPlugin.register(settings, (token) => {
            applicationSettings.setString("deviceId", token.trim());
        }, (error) => { console.log(error); });
        pushPlugin.onMessageReceived((message, d) => {
            let data = JSON.parse(d);
            alert({
                title: data.title,
                message: data.text,
                okButtonText: "Ok"
            })
            // let options: SnackBarOptions = {
            //     actionText: 'See Requests',
            //     actionTextColor: '#ff4081',
            //     snackText: data.notification,
            //     hideDelay: 6000
            // };

            // snackbar.action(options).then((args) => {
            //     if (args.command === "Action") {
            //         app.notify({
            //             eventName: 'see-requests'
            //         });
            //     }
            // });
        });
    } 
});

// declare var GMSServices: any;
// GMSServices.provideAPIKey("AIzaSyCoTmW5rNJsoZdR3PFlJ1fZ_Ogrwb02mtc");
platformNativeScriptDynamic().bootstrapModule(AppModule);
