import { BusStop } from "./bus-stop.model";

export interface BusRoute {
    id: string;  // RouteId (GUID)
    name: string;
    startPoint: string;
    endPoint: string;
    stops: BusStop[];  // Associated bus stops
  }
  