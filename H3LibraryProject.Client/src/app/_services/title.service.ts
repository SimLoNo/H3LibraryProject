import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MaterialTitle } from '../_models/title';

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

  readAllTitles():Observable<MaterialTitle[]>{
    return this.http.get<MaterialTitle[]>(this.baseUrl);
  }

  readTitleById(id:number):Observable<MaterialTitle>{
    return this.http.get<MaterialTitle>(`${this.baseUrl}/${id}`);
  }

  createTitle(newTitle:MaterialTitle):Observable<MaterialTitle>{
    return this.http.post<MaterialTitle>(this.baseUrl, newTitle, this.httpOptions);
  }

  updateTitle(id:number, updateTitle:MaterialTitle):Observable<MaterialTitle>{
    return this.http.put<MaterialTitle>(`${this.baseUrl}/${id}`, updateTitle, this.httpOptions);
  }

  deleteTitle(id:number):Observable<MaterialTitle>{
    return this.http.delete<MaterialTitle>(`${this.baseUrl}/${id}`);
  }
}
