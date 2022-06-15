import { MaterialService } from './../../_services/material.service';
import { Material } from './../../_models/material';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search-material',
  templateUrl: './search-material.component.html',
  styleUrls: ['./search-material.component.css']
})
export class SearchMaterialComponent implements OnInit {
  searchTitle:string = "";
  searchLocation:string = "";
  searchGenre:string = "";
  searchAuthor:string = "";
  //searchMaterial:Material = {materialId:0,titleId:0,locationId:0,home:false,title:{titleId:0,name:"",rYear:0,pages:0},location:{locationId:0,name:""}}
  materials:Material[] = [];
  constructor(private materialService:MaterialService) { }

  ngOnInit(): void {

  this.materialService.readAllMaterials()
  .subscribe((data) => {
    console.log(data);

    this.materials = data;
  })
  }
search(){
  this.materialService.readMaterialsBySearch(this.searchTitle,this.searchLocation,this.searchGenre,this.searchAuthor)
  .subscribe((data) => {
    if (data != null) {
      data.forEach(m => {
        console.log(`Materiale er modtaget: ${m.materialId}, ${m.title.name}`);

      })
      this.materials = data;
    }
    else
    {
      this.materials = [];
    }
  })
}


}
