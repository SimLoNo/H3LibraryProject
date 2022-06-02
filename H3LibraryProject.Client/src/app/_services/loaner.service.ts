import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Loaner } from '../_models/loaner';

@Injectable({
  providedIn: 'root'
})
export class LoanerService {
  private httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/Loaner";
  constructor(private http:HttpClient) { }

  readAllLoaners():Observable<Loaner[]>{
    return this.http.get<Loaner[]>(this.baseUrl);
  }

  readLoanerById(id:number):Observable<Loaner>{
    return this.http.get<Loaner>(`${this.baseUrl}/${id}`);
  }

  createLoaner(newLoaner:Loaner):Observable<Loaner>{
    return this.http.post<Loaner>(this.baseUrl, newLoaner, this.httpOptions);
  }

  updateLoaner(id:number, updateLoaner:Loaner):Observable<Loaner>{
    return this.http.put<Loaner>(`${this.baseUrl}/${id}`, updateLoaner, this.httpOptions);
  }

  deleteLoaner(id:number):Observable<Loaner>{
    return this.http.delete<Loaner>(`${this.baseUrl}/${id}`);
  }
}
