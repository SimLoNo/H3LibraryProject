import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Genre } from '../_models/genre';

@Injectable({
  providedIn: 'root'
})
export class GenreService {
  private httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/Genre";
  constructor(private http:HttpClient) { }

  readAllGenres():Observable<Genre[]>{
    return this.http.get<Genre[]>(this.baseUrl);
  }

  readGenreById(id:number):Observable<Genre>{
    return this.http.get<Genre>(`${this.baseUrl}/${id}`);
  }

  createGenre(newGenre:Genre):Observable<Genre>{
    return this.http.post<Genre>(this.baseUrl, newGenre, this.httpOptions);
  }

  updateGenre(id:number, updateGenre:Genre):Observable<Genre>{
    return this.http.put<Genre>(`${this.baseUrl}/${id}`, updateGenre, this.httpOptions);
  }

  deleteGenre(id:number):Observable<Genre>{
    return this.http.delete<Genre>(`${this.baseUrl}/${id}`);
  }
}
