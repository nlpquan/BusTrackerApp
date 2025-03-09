import { Bus } from "./bus.model";

export interface BusLocation {
    id: string;  // LocationId (GUID)
    busId: string;  // Associated BusId
    latitude: number;
    longitude: number;
    timestamp: string;  // ISO date string
    bus: Bus | null;  // Associated bus data
  }
  