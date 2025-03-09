import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HomepageComponent } from './components/homepage/homepage.component';  // Correct path
import { BusRouteMapComponent } from './components/bus-route-map/bus-route-map.component';  // Correct path

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    BusRouteMapComponent  // Declare the BusRouteMapComponent here
  ],
  imports: [
    BrowserModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
