import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoanerType } from '../_models/loanerType';

@Injectable({
  providedIn: 'root'
})
export class LoanerTypeService {
  private httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/LoanerType";
  constructor(private http:HttpClient) { }

  readAllLoanerTypes():Observable<LoanerType[]>{
    return this.http.get<LoanerType[]>(this.baseUrl);
  }

  readLoanerTypeById(id:number):Observable<LoanerType>{
    return this.http.get<LoanerType>(`${this.baseUrl}/${id}`);
  }

  createLoanerType(newLoanerType:LoanerType):Observable<LoanerType>{
    return this.http.post<LoanerType>(this.baseUrl, newLoanerType, this.httpOptions);
  }

  updateLoanerType(id:number, updateLoanerType:LoanerType):Observable<LoanerType>{
    return this.http.put<LoanerType>(`${this.baseUrl}/${id}`, updateLoanerType, this.httpOptions);
  }

  deleteLoanerType(id:number):Observable<LoanerType>{
    return this.http.delete<LoanerType>(`${this.baseUrl}/${id}`);
  }
}
