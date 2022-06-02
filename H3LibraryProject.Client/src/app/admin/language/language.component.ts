import { Language } from './../../_models/language';
import { Component, OnInit } from '@angular/core';
import { LanguageService } from 'src/app/_services/language.service';

@Component({
  selector: 'app-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.css']
})
export class LanguageComponent implements OnInit {

  adminPages:string[] = ['author','genre','language','loanertype','location','material','nationality','publisher','title','nationality'];
  languages:Language[] = [];
  currentLanguage:Language = {languageId:0,name:"",titles:[]};
  constructor(private languageService:LanguageService){}


  ngOnInit(): void {
    this.languageService.readAllLanguages()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.languages = data;
      }

    })
  }
  edit(Language:Language){
    console.log("selected Language: " + Language.name);

    this.currentLanguage = Language;
  }

  deleteLanguage(){
    if (confirm(`Er du sikker på at du vil slette languagen: ${this.currentLanguage.name}?`)) {
      this.languageService.deleteLanguage(this.currentLanguage.languageId)
      .subscribe(data => {
        console.log(`Deleted data is: ${data.languageId} ${data.name}`);
        this.languages = this.languages.filter(languageObj => languageObj.languageId != this.currentLanguage.languageId);
        this.reset();
      })
    }

  }

  saveLanguage(){
  if (this.currentLanguage.languageId <= 0 || this.currentLanguage.languageId == null) {
      this.languageService.createLanguage(this.currentLanguage)
      .subscribe(data => {
        console.log(`Save created new Language: ${data.languageId} ${data.name}`);
        this.languages.push(data);
        this.reset();
      })
    }
    else {
      this.languageService.updateLanguage(this.currentLanguage.languageId, this.currentLanguage)
      .subscribe(data =>{
        console.log(`Save updated existing Language: ${data.languageId} ${data.name}`);
        let LanguageIndex:number = this.languages.findIndex(languageObj => languageObj.languageId == this.currentLanguage.languageId);
        this.languages[LanguageIndex] = data;
        this.reset();
      })
    }

  }

  reset(){
    this.currentLanguage = {languageId:0, name:"",titles:[]};
  }

}
