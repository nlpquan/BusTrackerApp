import { BusLocation } from "./bus-location.model";
import { BusRoute } from "./bus-route.model";

export interface Bus {
    id: string;  // BusId (GUID)
    plateNumber: string;
    model: string;
    capacity: number;
    isActive: boolean;
    routes: BusRoute[];  // Associated bus routes
    location: BusLocation | null;  // Location data
  }
  