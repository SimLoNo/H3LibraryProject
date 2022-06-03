import { GenreService } from './../../_services/genre.service';
import { Genre } from './../../_models/genre';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.css']
})
export class GenreComponent implements OnInit {

  adminPages:string[] = ['author','genre','language','loan','loaner','loanertype','location','material','nationality','publisher','title'];
  genres:Genre[] = [];
  currentGenre:Genre = {genreId:0,name:"",leasePeriod:0};
  constructor(private genreService:GenreService){}


  ngOnInit(): void {
    this.genreService.readAllGenres()
    .subscribe((data) => {
      console.log(data);
      if (data != null) {
        this.genres = data;
      }

    })
  }
  edit(Genre:Genre){
    console.log("selected Genre: " + Genre.name);

    this.currentGenre = Genre;
  }

  deleteGenre(){
    if (confirm(`Er du sikker på at du vil slette genren: ${this.currentGenre.name}?`)) {
      this.genreService.deleteGenre(this.currentGenre.genreId)
      .subscribe(data => {
        console.log(`Deleted data is: ${data.genreId} ${data.name}`);
        this.genres = this.genres.filter(genreObj => genreObj.genreId != this.currentGenre.genreId);
        this.reset();
      })
    }

  }

  saveGenre(){
  if (this.currentGenre.genreId <= 0 || this.currentGenre.genreId == null) {
      this.genreService.createGenre(this.currentGenre)
      .subscribe(data => {
        console.log(`Save created new Genre: ${data.genreId} ${data.name}`);
        this.genres.push(data);
        this.reset();
      })
    }
    else {
      this.genreService.updateGenre(this.currentGenre.genreId, this.currentGenre)
      .subscribe(data =>{
        console.log(`Save updated existing Genre: ${data.genreId} ${data.name}`);
        let GenreIndex:number = this.genres.findIndex(genreObj => genreObj.genreId == this.currentGenre.genreId);
        this.genres[GenreIndex] = data;
        this.reset();
      })
    }

  }

  reset(){
    this.currentGenre = {genreId:0, name:"",leasePeriod:0};
  }

}
