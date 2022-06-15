import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LibLocation } from '../_models/location';

@Injectable({
  providedIn: 'root'
})
export class LocationService {
  private httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/Location";
  constructor(private http:HttpClient) { }

  readAllLocations():Observable<LibLocation[]>{
    return this.http.get<LibLocation[]>(this.baseUrl);
  }

  readLocationById(id:number):Observable<LibLocation>{
    return this.http.get<LibLocation>(`${this.baseUrl}/${id}`);
  }

  createLocation(newLocation:LibLocation):Observable<LibLocation>{
    return this.http.post<LibLocation>(this.baseUrl, newLocation, this.httpOptions);
  }

  updateLocation(id:number, updateLocation:LibLocation):Observable<LibLocation>{
    return this.http.put<LibLocation>(`${this.baseUrl}/${id}`, updateLocation, this.httpOptions);
  }

  deleteLocation(id:number):Observable<LibLocation>{
    return this.http.delete<LibLocation>(`${this.baseUrl}/${id}`);
  }
}
