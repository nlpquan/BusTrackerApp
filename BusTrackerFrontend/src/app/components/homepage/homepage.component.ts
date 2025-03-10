import { Component, OnInit } from '@angular/core';
import { BusRouteService } from '../../services/bus-route.service';  // Correct path from homepage.component.ts
import { BusLocationService } from '../../services/bus-location.service';  // Correct path from homepage.component.ts


@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {
  start: string = '';  // Start location
  end: string = '';  // End location
  routes: any[] = [];  // List of bus routes
  busLocations: any[] = [];  // List of bus locations

  constructor(
    private busRouteService: BusRouteService,  // Service for bus routes
    private busLocationService: BusLocationService  // Service for bus locations
  ) {}

  ngOnInit(): void {}

  // Handle form submission
  onSubmit(): void {
    // Temporary mock response for routes
    this.routes = [
      { routeName: 'Route 101' },
      { routeName: 'Route 102' }
    ];

    // Simulating fetching bus locations for selected route
    this.busLocationService.getBusLocations('1').subscribe(locations => {
      this.busLocations = locations;
    });
  }
}
