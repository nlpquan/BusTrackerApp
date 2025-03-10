import { Component } from '@angular/core';
import { RouterOutlet, RouterLink} from '@angular/router';

import { BusRouteMapComponent } from './components/bus-route-map/bus-route-map.component';
import { BusRouteSearchComponent } from './components/bus-route-search/bus-route-search.component';
import { LoginPageComponent } from './components/login-page/login-page.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, BusRouteMapComponent, BusRouteSearchComponent, LoginPageComponent, DashboardComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'Bus Tracker';
}


