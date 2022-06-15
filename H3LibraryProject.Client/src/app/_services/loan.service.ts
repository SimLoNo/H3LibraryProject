import { LoanMaterial } from './../_models/loan';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
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

  userLoan(loanerId:number,materialId:number,loanChange:number):Observable<Loan>{
    console.log(`userLoan data: ${loanerId}, ${materialId}, ${loanChange}`);
    let emptyLoan:Loan = {loanId:0,loanerId:0,materialId:0,loanDate:new Date(),returnDate:new Date(),isReturned:false,loaner:{loanerId:0,loanerTypeId:0,loanerTypeName:"",name:""},material:{materialId:0,titleId:0,locationId:0,titleName:""}}
    let queryOptions= new HttpParams();
    queryOptions = queryOptions.append("loanerId",loanerId);
    queryOptions = queryOptions.append("materialId",materialId);
    queryOptions = queryOptions.append("loanChange",loanChange);
    let loanHttpOptions = {
      headers: new HttpHeaders({
        'content-type': 'application/json'
      }),
      params: queryOptions
    }
    console.log(`query data: ${queryOptions.get("loanerId")}, ${queryOptions.get("materialId")}, ${queryOptions.get("loanChange")}`);
    return this.http.put<Loan>(this.baseUrl, emptyLoan, loanHttpOptions);
  }

  readLoanByLoanerId(loanerId:number):Observable<Loan[]>{
    let queryOptions = new HttpParams();
    queryOptions = queryOptions.append("loanerId",loanerId);
    return this.http.get<Loan[]>(this.baseUrl,{params:queryOptions});
  }
}
