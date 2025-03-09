import { Component, Input, OnInit } from '@angular/core';
import * as L from 'leaflet';

@Component({
  selector: 'app-bus-route-map',
  templateUrl: './bus-route-map.component.html',
  styleUrls: ['./bus-route-map.component.css']
})
export class BusRouteMapComponent implements OnInit {
  @Input() routeCoordinates: any[] = [];  // Input property to receive route data
  map: L.Map | undefined;

  ngOnInit() {
    // Initialize the map only once the component is initialized
    this.initializeMap();
  }

  // Function to initialize the map
  private initializeMap() {
    this.map = L.map('map').setView([40.73061, -73.935242], 12);  // Set default to New York

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; OpenStreetMap contributors'
    }).addTo(this.map);
  }

  plotRouteOnMap(routeCoordinates: any[]) {
    if (this.map) {
      // Ensure the route coordinates are in the correct format [lat, lng]
      const latLngs: [number, number][] = routeCoordinates
        .map((coord: any) => {
          if (Array.isArray(coord) && coord.length === 2) {
            // Ensure each coordinate is a LatLngTuple (i.e., [lat, lng])
            return [coord[0], coord[1]] as [number, number]; // Explicitly cast to [number, number]
          }
          return null;  // If the coordinate is invalid, return null
        })
        .filter((coord): coord is [number, number] => coord !== null);  // Filter out any null values
  
      // Check if we have valid coordinates before proceeding
      if (latLngs.length > 0) {
        // Plot the bus route using polyline
        L.polyline(latLngs, { color: 'blue' }).addTo(this.map);
  
        // Fit the map bounds to the route coordinates
        this.map.fitBounds(latLngs); // `fitBounds` accepts LatLngBoundsExpression, which is [LatLngTuple[]]
      } else {
        console.error('Invalid route coordinates');
      }
    }
  }
  
}
