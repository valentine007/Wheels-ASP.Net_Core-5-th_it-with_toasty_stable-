import { NgModule, ErrorHandler } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ToastyModule } from 'ng2-toasty';
import { BrowserModule } from "@angular/platform-browser";

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { VehicleFormComponent } from './components/vehicle-module/vehicle-form/vehicle-form.component';
import { VehicleService } from './services/vehicle.service';
import { AppErrorHandler } from './app.error-handler';
import { VehicleListComponent } from './components/vehicle-module/vehicle-list/vehicle-list';
import { PaginationComponent } from './components/shared/pagination.component';
import { ViewVehicleComponent } from './components/vehicle-module/view-vehicle/view-vehicle';

@NgModule({
	bootstrap: [AppComponent],
    declarations: [
		AppComponent,
		NavMenuComponent,
		CounterComponent,
		FetchDataComponent,
		HomeComponent,
		VehicleFormComponent,
		VehicleListComponent,
		ViewVehicleComponent,
		PaginationComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
		FormsModule,
		ToastyModule.forRoot(),
		BrowserModule,
        RouterModule.forRoot([
			{ path: '', redirectTo: 'vehicles', pathMatch: 'full' },
			{ path: 'vehicles/new', component: VehicleFormComponent },
			{ path: 'vehicles/edit/:id', component: VehicleFormComponent },
			{ path: 'vehicles/:id', component: ViewVehicleComponent },
			{ path: 'vehicles', component: VehicleListComponent },
			{ path: 'home', component: HomeComponent },
			{ path: 'counter', component: CounterComponent },
			{ path: 'fetch-data', component: FetchDataComponent },
			{ path: '**', redirectTo: 'home' }
        ])
	],
	providers: [
		{ provide: ErrorHandler, useClass: AppErrorHandler },
		VehicleService
	],
})
export class AppModuleShared {
}
