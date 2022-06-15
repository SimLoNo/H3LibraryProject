import { Component, OnInit } from '@angular/core';
import { LibLocation } from 'src/app/_models/location';
import { LocationService } from 'src/app/_services/location.service';

@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrls: ['./location.component.css']
})
export class LocationComponent implements OnInit {
  adminPages:string[] = ['author','genre','language','loan','loaner','loanertype','location','material','nationality','publisher','title'];
  locations:LibLocation[] = [];
  currentLocation:LibLocation = {locationId:0,name:"",materials:[]};
  constructor(private locationService: LocationService) { }


  ngOnInit(): void {
    this.locationService.readAllLocations()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.locations = data;
      }

    })
  }
  edit(location:LibLocation){
    console.log("selected location: " + location.name);

    this.currentLocation = location;
  }

  deleteLocation(){
    if (confirm(`Er du sikker på at du vil slette sproget: ${this.currentLocation.name}?`)) {
      this.locationService.deleteLocation(this.currentLocation.locationId)
      .subscribe(data => {
        console.log(`Deleted data is: ${data.locationId} ${data.name}`);
        this.locations = this.locations.filter(locationObj => locationObj.locationId != this.currentLocation.locationId);
        this.reset();
      })
    }

  }

  saveLocation(){
  if (this.currentLocation.locationId <= 0 || this.currentLocation.locationId == null) {
      this.locationService.createLocation(this.currentLocation)
      .subscribe(data => {
        console.log(`Save created new location: ${data.locationId} ${data.name}`);
        this.locations.push(data);
        this.reset();
      })
    }
    else {
      this.locationService.updateLocation(this.currentLocation.locationId, this.currentLocation)
      .subscribe(data =>{
        console.log(`Save updated existing location: ${data.locationId} ${data.name}`);
        let locationIndex:number = this.locations.findIndex(locationObj => locationObj.locationId == this.currentLocation.locationId);
        this.locations[locationIndex] = data;
        this.reset();
      })
    }

  }

  reset(){
    this.currentLocation = {locationId:0, name:""};
  }

}
