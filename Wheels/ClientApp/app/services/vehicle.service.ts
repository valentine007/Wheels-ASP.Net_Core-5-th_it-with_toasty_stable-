import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';
import { SaveVehicle } from '../components/app/models/vehicle';

@Injectable()
export class VehicleService {

	constructor(private http: Http) { }

	getFeatures() {
		return this.http.get('/api/features')
			.map(res => res.json());
	}

	getMakes() {
		return this.http.get('/api/makes')
			.map(res => res.json());
	}

	create(vehicle) {
		return this.http.post('/api/vehicles', vehicle)
			.map(res => res.json());
	}

	getVehicle(id) {
		return this.http.get('/api/vehicles/' + id)
			.map(res => res.json());
	}

	update(vehicle: SaveVehicle) {
		return this.http.put('/api/vehicles/' + vehicle.id, vehicle)
			.map(res => res.json());
	}
}