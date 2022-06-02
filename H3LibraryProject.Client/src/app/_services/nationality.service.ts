import { Nationality } from './../_models/nationality';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NationalityService {
  private httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/Nationality";
  constructor(private http:HttpClient) { }

  readAllNationalities():Observable<Nationality[]>{
    return this.http.get<Nationality[]>(this.baseUrl);
  }

  readNationalityById(id:number):Observable<Nationality>{
    return this.http.get<Nationality>(`${this.baseUrl}/${id}`);
  }

  createNationality(newNationality:Nationality):Observable<Nationality>{
    return this.http.post<Nationality>(this.baseUrl, newNationality, this.httpOptions);
  }

  updateNationality(id:number, updateNationality:Nationality):Observable<Nationality>{
    return this.http.put<Nationality>(`${this.baseUrl}/${id}`, updateNationality, this.httpOptions);
  }

  deleteNationality(id:number):Observable<Nationality>{
    return this.http.delete<Nationality>(`${this.baseUrl}/${id}`);
  }
}


