import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Loan } from '../_models/loan';

@Injectable({
  providedIn: 'root'
})
export class LoanService {
  private httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/Loan";
  constructor(private http:HttpClient) { }

  readAllLoans():Observable<Loan[]>{
    return this.http.get<Loan[]>(this.baseUrl);
  }

  readLoanById(id:number):Observable<Loan>{
    return this.http.get<Loan>(`${this.baseUrl}/${id}`);
  }

  createLoan(newLoan:Loan):Observable<Loan>{
    return this.http.post<Loan>(this.baseUrl, newLoan, this.httpOptions);
  }

  updateLoan(id:number, updateLoan:Loan):Observable<Loan>{
    return this.http.put<Loan>(`${this.baseUrl}/${id}`, updateLoan, this.httpOptions);
  }

  deleteLoan(id:number):Observable<Loan>{
    return this.http.delete<Loan>(`${this.baseUrl}/${id}`);
  }
}
