import { VehicleStockAccessory } from "./vehicleStockAccessory";
import { VehicleStockImage } from "./vehicleStockImage";

export interface VehicleStockItem {
  id: number;
  registrationNumber: string;
  manufacturer: string;
  modelDescription: string;
  modelYear: number;
  currentKilometreReading: number;
  colour: string;
  vinNumber: string;
  retailPrice: number;
  costPrice: number;
  createdDate: string;
  createdBy: string,
  modifiedDate: string;
  accessories: Array<VehicleStockAccessory>;
  images: Array<VehicleStockImage>;
}
