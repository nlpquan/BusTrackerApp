import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BusRouteService {
  private apiUrl = 'http://your-backend-api-url/api/bus-routes'; // Replace with your backend API

  constructor(private http: HttpClient) {}

  getBusRoutes(start: string, end: string): Observable<any> {
    // Call to the backend API to get bus routes based on start and end locations
    return this.http.get<any>(`${this.apiUrl}?start=${start}&end=${end}`);
  }
}
