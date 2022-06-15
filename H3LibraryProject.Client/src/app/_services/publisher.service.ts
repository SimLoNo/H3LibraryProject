import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Publisher } from '../_models/publisher';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {
  private httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/Publisher";
  constructor(private http:HttpClient) { }

  readAllPublishers():Observable<Publisher[]>{
    return this.http.get<Publisher[]>(this.baseUrl);
  }

  readPublisherById(id:number):Observable<Publisher>{
    return this.http.get<Publisher>(`${this.baseUrl}/${id}`);
  }

  createPublisher(newPublisher:Publisher):Observable<Publisher>{
    return this.http.post<Publisher>(this.baseUrl, newPublisher, this.httpOptions);
  }

  updatePublisher(id:number, updatePublisher:Publisher):Observable<Publisher>{
    return this.http.put<Publisher>(`${this.baseUrl}/${id}`, updatePublisher, this.httpOptions);
  }

  deletePublisher(id:number):Observable<Publisher>{
    return this.http.delete<Publisher>(`${this.baseUrl}/${id}`);
  }
}
