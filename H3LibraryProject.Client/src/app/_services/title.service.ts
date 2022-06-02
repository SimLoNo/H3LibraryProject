import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Title } from '@angular/platform-browser';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TitleService {
  private httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/Title";
  constructor(private http:HttpClient) { }

  readAllTitles():Observable<Title[]>{
    return this.http.get<Title[]>(this.baseUrl);
  }

  readTitleById(id:number):Observable<Title>{
    return this.http.get<Title>(`${this.baseUrl}/${id}`);
  }

  createTitle(newTitle:Title):Observable<Title>{
    return this.http.post<Title>(this.baseUrl, newTitle, this.httpOptions);
  }

  updateTitle(id:number, updateTitle:Title):Observable<Title>{
    return this.http.put<Title>(`${this.baseUrl}/${id}`, updateTitle, this.httpOptions);
  }

  deleteTitle(id:number):Observable<Title>{
    return this.http.delete<Title>(`${this.baseUrl}/${id}`);
  }
}
