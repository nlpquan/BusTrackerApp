import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  // Import HttpClient to make API requests
import { Observable } from 'rxjs';  // Import Observable for handling async operations

@Injectable({
  providedIn: 'root'  // This ensures the service is available app-wide
})
export class BusLocationService {
  private apiUrl = '/api/bus-locations';  // Replace with your actual API endpoint

  constructor(private http: HttpClient) { }

  // Method to fetch bus locations (replace with actual API call)
  getBusLocations(routeId: string): Observable<any> {
    // Make a GET request to the backend to fetch bus locations for a specific route
    return this.http.get<any>(`${this.apiUrl}?routeId=${routeId}`);
  }
}
