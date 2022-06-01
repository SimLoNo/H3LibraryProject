import { Nationality } from '../_models/nationality';
import { Injectable } from '@angular/core';
import { from, Observable } from 'rxjs';
import {HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NationalityService {

  private httpOptions = {
    Headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/Nationality";
  constructor(private http:HttpClient) { }

  readAllNationalities():Observable<Nationality[]>{
    return this.http.get<Nationality[]>(this.baseUrl);
  }
}


