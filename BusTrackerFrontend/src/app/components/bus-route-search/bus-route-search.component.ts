import { Component } from '@angular/core';
import { BusRouteService } from '../../services/bus-route.service';  // Correct path

@Component({
  selector: 'app-bus-route-search',
  templateUrl: './bus-route-search.component.html',
  styleUrls: ['./bus-route-search.component.css']
})
export class BusRouteSearchComponent {
  start: string = '';
  end: string = '';
  routes: any[] = [];  // Array to store the fetched bus routes

  constructor(private busRouteService: BusRouteService) {}

  onSubmit() {
    if (this.start && this.end) {
      this.busRouteService.getBusRoutes(this.start, this.end).subscribe(
        (data) => {
          this.routes = data.routes;  // Assuming the response contains a 'routes' array
          console.log('Fetched Routes:', this.routes);
          // You can now pass the data to the map component to plot routes
        },
        (error) => {
          console.error('Error fetching routes', error);
        }
      );
    }
  }
}
