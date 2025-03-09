import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BusRouteSearchComponent } from './components/bus-route-search/bus-route-search.component';
import { BusRouteMapComponent } from './components/bus-route-map/bus-route-map.component';
import { HomepageComponent } from './components/homepage/homepage.component'; // Path to the homepage component

export const routes: Routes = [
  { path: '', component: HomepageComponent },  // Set homepage as the default route
  { path: 'map', component: BusRouteMapComponent }  // Route for the map view
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
