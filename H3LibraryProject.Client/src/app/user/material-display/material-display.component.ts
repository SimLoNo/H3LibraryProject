import { Material } from './../../_models/material';
import { MaterialService } from './../../_services/material.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-material-display',
  templateUrl: './material-display.component.html',
  styleUrls: ['./material-display.component.css']
})
export class MaterialDisplayComponent implements OnInit {

  constructor(private materialService:MaterialService, private route: ActivatedRoute) { }
  materialId:number = 0;
  material:Material = {materialId:0,titleId:0,locationId:0,home:false,title:{titleId:0,name:"",rYear:0,pages:0,authors:[]},location:{locationId:0,name:""}};
  ngOnInit(): void {
    this.route.paramMap
      .subscribe(params => {
        this.materialId = Number(params.get('id'));
        this.materialService.readMaterialById(this.materialId)
          .subscribe((data) => {
            data.title.authors.forEach(a =>{
              console.log(`Author: ${a.authorId}, ${a.lName}`);

            })
            this.material = data
          });
      })
  }

}
