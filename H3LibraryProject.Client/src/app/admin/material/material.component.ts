import { Material } from './../../_models/material';
import { MaterialService } from './../../_services/material.service';
import { PublisherService } from './../../_services/publisher.service';
import { LocationService } from './../../_services/location.service';
import { Publisher } from './../../_models/publisher';
import { Component, OnInit } from '@angular/core';
import { MaterialTitle } from 'src/app/_models/title';
import { TitleService } from 'src/app/_services/title.service';
import { LibLocation } from 'src/app/_models/location';

@Component({
  selector: 'app-material',
  templateUrl: './material.component.html',
  styleUrls: ['./material.component.css']
})
export class MaterialComponent implements OnInit {
  adminPages:string[] = ['author','genre','language','loan','loaner','loanertype','location','material','nationality','publisher','title'];
  titles:MaterialTitle[] = [];
  locations:LibLocation[] = [];
  publishers:Publisher[] = [];
  materials:Material[] = [];
  currentMaterial:Material = {materialId:0,titleId:0,locationId:0,home:false,location:{locationId:0,name:""},title:{titleId:0,name:"",rYear:0,pages:0,authors:[]}};
  authorSelect:number = 0;
  constructor(private locationService: LocationService, private publisherService:PublisherService, private titleService:TitleService, private materialService:MaterialService) { }


  ngOnInit(): void {

    // Henter alle forfattere
    this.locationService.readAllLocations()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.locations = data;
      }

    });

    // Henter alle udgivere
    this.publisherService.readAllPublishers()
    .subscribe((data) => {
      if (data != null) {
        this.publishers = data;
      }
    })

    // Henter alle titler
    this.titleService.readAllTitles()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.titles = data;
      }

    })

    // Henter alle titler
    this.materialService.readAllMaterials()
    .subscribe((data) => {
      console.log(data);
      data.forEach(m => {
        console.log(`Material: id: ${m.materialId}, location: ${m.location.name}, title name: ${m.title.name}`);

      })
      if (data != null) {
        this.materials = data;
      }

    })
  }
  edit(material:Material){
    this.currentMaterial = material;

  }

  deleteMaterial(){
    if (confirm(`Er du sikker på at du vil slette materialet: ${this.currentMaterial.materialId}, ${this.currentMaterial.title.name} ${this.currentMaterial.location.name}?`)) {
      this.materialService.deleteMaterial(this.currentMaterial.materialId)
      .subscribe(data => {
        console.log(`Deleted data is: ${data.materialId}`);
        this.materials = this.materials.filter(materialObj => materialObj.materialId != this.currentMaterial.materialId);
        this.reset();
      })
    }

  }

  saveMaterial(){

  if (this.currentMaterial.materialId <= 0 || this.currentMaterial.materialId == null) {
      this.materialService.createMaterial(this.currentMaterial)
      .subscribe(data => {
        this.materials.push(data);
        this.reset();
      })
    }
    else {

      this.materialService.updateMaterial(this.currentMaterial.materialId, this.currentMaterial)
      .subscribe(data =>{
        let materialIndex:number = this.materials.findIndex(materialObj => materialObj.materialId == data.materialId);
        this.materials[materialIndex] = data;
        this.reset();
      })
    }

  }



  reset(){
    this.currentMaterial = {materialId:0,titleId:0,locationId:0,home:false,location:{locationId:0,name:""},title:{titleId:0,name:"",rYear:0,pages:0,authors:[]}};
  }
}
