import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Language } from '../_models/language';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  private httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/Language";
  constructor(private http:HttpClient) { }

  readAllLanguages():Observable<Language[]>{
    return this.http.get<Language[]>(this.baseUrl);
  }

  readLanguageById(id:number):Observable<Language>{
    return this.http.get<Language>(`${this.baseUrl}/${id}`);
  }

  createLanguage(newLanguage:Language):Observable<Language>{
    return this.http.post<Language>(this.baseUrl, newLanguage, this.httpOptions);
  }

  updateLanguage(id:number, updateLanguage:Language):Observable<Language>{
    return this.http.put<Language>(`${this.baseUrl}/${id}`, updateLanguage, this.httpOptions);
  }

  deleteLanguage(id:number):Observable<Language>{
    return this.http.delete<Language>(`${this.baseUrl}/${id}`);
  }
}
