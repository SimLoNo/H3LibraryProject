import { Author } from './../_models/author';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthorService {
  private httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/author";
  constructor(private http:HttpClient) { }

  readAllAuthors():Observable<Author[]>{
    return this.http.get<Author[]>(this.baseUrl);
  }

  readAuthorById(id:number):Observable<Author>{
    return this.http.get<Author>(`${this.baseUrl}/${id}`);
  }

  createAuthor(newAuthor:Author):Observable<Author>{
    return this.http.post<Author>(this.baseUrl, newAuthor, this.httpOptions);
  }

  updateAuthor(id:number, updateAuthor:Author):Observable<Author>{
    return this.http.put<Author>(`${this.baseUrl}/${id}`, updateAuthor, this.httpOptions);
  }

  deleteAuthor(id:number):Observable<Author>{
    return this.http.delete<Author>(`${this.baseUrl}/${id}`);
  }
}
