import { LoanService } from './../../_services/loan.service';
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

  constructor(private materialService:MaterialService, private loanService:LoanService, private route: ActivatedRoute) { }
  materialId:number = 0;
  material:Material = {materialId:0,titleId:0,locationId:0,home:false,title:{titleId:0,name:"",rYear:0,pages:0,authors:[]},location:{locationId:0,name:""}};
  ngOnInit(): void {
    this.route.paramMap
      .subscribe(params => {
        this.materialId = Number(params.get('id'));
        this.materialService.readMaterialById(this.materialId)
          .subscribe((data) => {
            console.log(`material is: ${data.title.name}, is home: ${data.home}`);

            data.title.authors.forEach(a =>{
              console.log(`Author: ${a.authorId}, ${a.lName}`);

            })
            this.material = data
          });
      })
  }

  loanMaterial(){
    // Det første hardcoded tal, skal rettes til den indloggede brugers id, når vi har fået login til at virke. Det sidste hardcoded tal skal forblive 1,
    // som er koden for at oprette et lån i API'et.
    this.loanService.userLoan(1,this.materialId, 1)
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        console.log("Data er ikke null");

        this.material.home = false;
        console.log(`CurrentMaterial hjemmestatus: ${this.material.home}`);

      }

    }) // Vi skal finde ud af en måde at sige til brugeren at lånet er gået igennem.
  }

}
