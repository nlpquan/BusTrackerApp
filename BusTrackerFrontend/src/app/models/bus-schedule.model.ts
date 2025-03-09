import { BusRoute } from "./bus-route.model";
import { Bus } from "./bus.model";

export interface BusSchedule {
    id: string;  // ScheduleId (GUID)
    busId: string;  // Associated BusId
    routeId: string;  // Associated RouteId
    departureTime: string;  // ISO date string
    arrivalTime: string;  // ISO date string
    bus: Bus | null;  // Associated bus data
    route: BusRoute | null;  // Associated route data
  }
  