import { Publisher } from 'src/app/_models/publisher';
import { PublisherService } from 'src/app/_services/publisher.service';
import { GenreService } from './../../_services/genre.service';
import { Language } from './../../_models/language';
import { MaterialTitle } from 'src/app/_models/title';
import { Component, OnInit } from '@angular/core';
import { Nationality } from 'src/app/_models/nationality';
import { TitleService } from 'src/app/_services/title.service';
import { NationalityService } from 'src/app/_services/nationality.service';
import { AuthorService } from 'src/app/_services/author.service';
import { Author } from 'src/app/_models/author';
import { LanguageService } from 'src/app/_services/language.service';
import { Genre } from 'src/app/_models/genre';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.css']
})
export class TitleComponent implements OnInit {
  adminPages:string[] = ['author','genre','language','loan','loaner','loanertype','location','material','nationality','publisher','title'];
  titles:MaterialTitle[] = [];
  languages:Language[] = [];
  genres:Genre[] = [];
  publishers:Publisher[] = [];
  currentTitle:MaterialTitle = {titleId:0,name:"",languageId:0,rYear:0,pages:0,publisherId:0,genreId:0,materials:[],authorsList:[]};
  currentNationality:Nationality = {nationalityId:0, name:""};
  //authorTitles = new FormControl();
  authors:Author[] = [];
  unaddedAuthors:Author[] = [];
  addedAuthors:Author[] = [];
  authorSelect:number = 0;
  constructor(private authorService: AuthorService, private languageService:LanguageService, private titleService:TitleService, private genreService:GenreService, private publisherService:PublisherService) { }


  ngOnInit(): void {

    // Henter alle forfattere
    this.authorService.readAllAuthors()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        data.forEach(element => {
          console.log(`author name: ${element.fName} ${element.mName} ${element.lName}, ${element.titles}`);
          element.titles?.forEach(a => {
            console.log(`Author with titles: ${a.genreId}, ${a.name}`);

          })
          if (element.mName == null) {
            // element.mName = "";
          }
        });
        this.authors = data;
        this.unaddedAuthors = data;
      }

    });

    // Henter alle udgivere
    this.publisherService.readAllPublishers()
    .subscribe((data) => {
      if (data != null) {
        this.publishers = data;
      }
    })

    // Henter alle nationaliteter
    this.languageService.readAllLanguages()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.languages = data;
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

    this.genreService.readAllGenres()
    .subscribe((data) => {
      if(data != null){
        this.genres = data;
      }
    })
  }
  edit(title:MaterialTitle){
    title.author?.forEach(a =>{
      console.log(`title has author: ${a}`);

    })
    console.log(`titleId: ${title.titleId}`);

    this.unaddedAuthors = [];
    this.addedAuthors = [];
    this.authors.forEach(t => {
      if (title.author?.find(b => b.authorId == t.authorId)) {
        this.addedAuthors.push(t);
      }
      else{
        this.unaddedAuthors.push(t);
      }
    })

    this.currentTitle = title;

  }

  deleteTitle(){
    if (confirm(`Er du sikker på at du vil slette titlen: ${this.currentTitle.name} ${this.currentTitle.rYear}?`)) {
      this.titleService.deleteTitle(this.currentTitle.titleId)
      .subscribe(data => {
        console.log(`Deleted data is: ${data.titleId} ${this.currentTitle.name}`);
        this.titles = this.titles.filter(titleObj => titleObj.titleId != this.currentTitle.titleId);
        this.reset();
      })
    }

  }

  saveTitle(){
    console.log(`Saved title: id: ${this.currentTitle.titleId}, title name: ${this.currentTitle.name}`);

    this.currentTitle.authorsList = []; // Sørger for at titleslist er en tom liste.

    // For hver titel der er markeret som tilføjet, bliver id'et til titlesList, som så sendes til API'et.
    this.addedAuthors.forEach(t => {
      this.currentTitle.authorsList.push(t.authorId);
      console.log(`Added to authorsList: ${t.authorId}, ${t.fName}`);

    })

    // nulstiller de lister der holder de tilføjede og utilføjede titler.
    this.addedAuthors = [];
    this.unaddedAuthors = this.authors;


  if (this.currentTitle.titleId <= 0 || this.currentTitle.titleId == null) {
      this.titleService.createTitle(this.currentTitle)
      .subscribe(data => {
        console.log(`Save created new author: ${data.titleId} ${data.name} ${data.rYear}`);
        this.titles.push(data);
        this.reset();
      })
    }
    else {
      // Debug sektion start
      console.log(`Update debug log`);
      this.currentTitle.author?.forEach(a => {
        console.log(`Title has author: ${a.authorId}, ${a.lName}`);

      })
      console.log(`titleId: ${this.currentTitle.titleId}`);

      console.log("Update debug log end");

      // Debug sektion slut
      this.titleService.updateTitle(this.currentTitle.titleId, this.currentTitle)
      .subscribe(data =>{
        console.log(`Save updated existing title: ${data.titleId} ${data.name} ${data.rYear}`);
        let titleIndex:number = this.authors.findIndex(authorObj => authorObj.authorId == this.currentTitle.titleId);
        this.titles[titleIndex] = data;
        this.reset();
      })
    }

  }

  removeAuthor(author:Author){
    this.addedAuthors = this.addedAuthors.filter(t => t.authorId != author.authorId); // Returnere den samme liste, undtagen det object der blev fjernet
    this.unaddedAuthors.push(author);
    this.authorSelect = 0; // nulstiller select menuen, for hver gang den er brugt.
  }
  addAuthor(author:Author){
    this.unaddedAuthors = this.unaddedAuthors.filter(t => t.authorId != author.authorId); // Returnere den samme liste, undtagen det object der blev tilføjet
    this.addedAuthors.push(author);
    this.authorSelect = 0; // nulstiller select menuen, for hver gang den er brugt.
  }

  reset(){
    this.addedAuthors = [];
    this.unaddedAuthors = this.authors;
    this.currentTitle = {titleId:0,name:"",languageId:0,rYear:0,pages:0,publisherId:0,genreId:0,materials:[],authorsList:[]};
  }
}
