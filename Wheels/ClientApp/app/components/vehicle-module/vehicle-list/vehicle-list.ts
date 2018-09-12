import { Component, OnInit } from '@angular/core';
import { Vehicle } from '../../app/models/vehicle';
import { VehicleService } from '../../../services/vehicle.service';
@Component({
	templateUrl: 'vehicle-list.html'
})
export class VehicleListComponent implements OnInit {
	vehicles: Vehicle[];
	constructor(private vehicleService: VehicleService) { }
	ngOnInit() {
		this.vehicleService.getVehicles()
			.subscribe(vehicles => this.vehicles = vehicles);
	}
}