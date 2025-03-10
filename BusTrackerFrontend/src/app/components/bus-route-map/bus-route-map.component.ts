import { Component, AfterViewInit } from '@angular/core';
import * as L from 'leaflet';
import { Control } from 'leaflet';

@Component({
  selector: 'app-bus-route-map',
  standalone: true,
  templateUrl: './bus-route-map.component.html',
  styleUrls: ['./bus-route-map.component.css']
})
export class BusRouteMapComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    const map = L.map('map').setView([51.505, -0.09], 13); // Set the initial map view

    // Add OpenStreetMap tile layer
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png').addTo(map);

    // Add a custom control (optional)
    const control = new Control({ position: 'topright' });
    control.onAdd = function () {
      const div = L.DomUtil.create('div', 'test-control'); // Create div for custom control
      div.innerHTML = 'Test Control'; // Add text content
      return div;
    };
    control.addTo(map);
  }
}
