import { TitleService } from './../../_services/title.service';
import { NationalityService } from './../../_services/nationality.service';
import { Nationality } from './../../_models/nationality';
import { Component, OnInit } from '@angular/core';
import { Author } from 'src/app/_models/author';
import { AuthorService } from 'src/app/_services/author.service';
import { FormControl, ReactiveFormsModule } from '@angular/forms';
import { MaterialTitle } from 'src/app/_models/title';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.css']
})
export class AuthorComponent implements OnInit {
  adminPages:string[] = ['author','genre','language','loan','loaner','loanertype','location','material','nationality','publisher','title'];
  authors:Author[] = [];
  nationalities:Nationality[] = [];
  currentAuthor:Author = {authorId:0,lName:"",fName:"",mName:"",bYear:0,dYear:0,nationalityId:0,};
  currentNationality:Nationality = {nationalityId:0, name:""};
  authorTitles = new FormControl();
  titles:MaterialTitle[] = [];
  constructor(private authorService: AuthorService, private nationalityService:NationalityService, private titleService:TitleService) { }


  ngOnInit(): void {
    this.authorService.readAllAuthors()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        data.forEach(element => {
          console.log(`author name: ${element.fName} ${element.mName} ${element.lName}, ${element.titles}`);
          if (element.mName == null) {
            // element.mName = "";
          }
        });
        this.authors = data;
      }

    });

    this.nationalityService.readAllNationalities()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.nationalities = data;
      }

    })

    this.titleService.readAllTitles()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.titles = data;
      }

    })
  }
  edit(author:Author){
    console.log(`selected author: ${author.fName} ${author.mName} ${author.lName}`);

    this.currentAuthor = author;
  }

  deleteAuthor(){
    if (confirm(`Er du sikker på at du vil slette sproget: ${this.currentAuthor.fName} ${this.currentAuthor.mName} ${this.currentAuthor.lName} ${this.currentAuthor.bYear} - ${this.currentAuthor.dYear}?`)) {
      this.authorService.deleteAuthor(this.currentAuthor.authorId)
      .subscribe(data => {
        console.log(`Deleted data is: ${data.authorId} ${this.currentAuthor.fName} ${this.currentAuthor.mName} ${this.currentAuthor.lName} ${this.currentAuthor.bYear} - ${this.currentAuthor.dYear}`);
        this.authors = this.authors.filter(authorObj => authorObj.authorId != this.currentAuthor.authorId);
        this.reset();
      })
    }

  }

  saveAuthor(){
    console.log(`Saved author: id: ${this.currentAuthor.authorId}, author name: ${this.currentAuthor.fName} ${this.currentAuthor.mName} ${this.currentAuthor.lName}`);

  if (this.currentAuthor.authorId <= 0 || this.currentAuthor.authorId == null) {
      this.authorService.createAuthor(this.currentAuthor)
      .subscribe(data => {
        console.log(`Save created new author: ${data.authorId} ${data.fName} ${data.mName} ${data.lName}`);
        this.authors.push(data);
        this.reset();
      })
    }
    else {
      this.authorService.updateAuthor(this.currentAuthor.authorId, this.currentAuthor)
      .subscribe(data =>{
        console.log(`Save updated existing author: ${data.authorId} ${data.fName} ${data.mName} ${data.lName}`);
        let authorIndex:number = this.authors.findIndex(authorObj => authorObj.authorId == this.currentAuthor.authorId);
        this.authors[authorIndex] = data;
        this.reset();
      })
    }

  }

  reset(){
    this.currentAuthor = {authorId:0, fName:"",mName:"",lName:"",nationalityId:0, bYear:0,dYear:0};
  }

}
