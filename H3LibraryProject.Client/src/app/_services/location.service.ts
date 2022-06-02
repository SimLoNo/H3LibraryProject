import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

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

  readAllLocations():Observable<Location[]>{
    return this.http.get<Location[]>(this.baseUrl);
  }

  readLocationById(id:number):Observable<Location>{
    return this.http.get<Location>(`${this.baseUrl}/${id}`);
  }

  createLocation(newLocation:Location):Observable<Location>{
    return this.http.post<Location>(this.baseUrl, newLocation, this.httpOptions);
  }

  updateLocation(id:number, updateLocation:Location):Observable<Location>{
    return this.http.put<Location>(`${this.baseUrl}/${id}`, updateLocation, this.httpOptions);
  }

  deleteLocation(id:number):Observable<Location>{
    return this.http.delete<Location>(`${this.baseUrl}/${id}`);
  }
}
