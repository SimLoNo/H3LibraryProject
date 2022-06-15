import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Loaner } from '../_models/loaner';
import { LoanerAuthenticator } from '../_models/LoanerAuthenticator';

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


  updateUserLoaner(updateLoaner:Loaner, loanerAuth:LoanerAuthenticator):Observable<Loaner>{

    let queryOptions = new HttpParams();
    queryOptions = queryOptions.append("name",loanerAuth.name);
    queryOptions = queryOptions.append("password",loanerAuth.password);
    let loanHttpOptions = {
      headers:new HttpHeaders({
        'content-type': 'application/json'
      }),
      params: queryOptions
    }


    return this.http.put<Loaner>(`${this.baseUrl}/userEdit`, updateLoaner, loanHttpOptions);
  }

  deleteLoaner(id:number):Observable<Loaner>{
    return this.http.delete<Loaner>(`${this.baseUrl}/${id}`);
  }
}
