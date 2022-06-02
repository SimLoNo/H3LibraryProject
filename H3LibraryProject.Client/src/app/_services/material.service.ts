import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Material } from '../_models/material';

@Injectable({
  providedIn: 'root'
})
export class MaterialService {
  private httpOptions = {
    headers: new HttpHeaders({
      'content-type': 'application/json'
    })
  }

  baseUrl:string = "https://localhost:44312/api/Material";
  constructor(private http:HttpClient) { }

  readAllMaterials():Observable<Material[]>{
    return this.http.get<Material[]>(this.baseUrl);
  }

  readMaterialById(id:number):Observable<Material>{
    return this.http.get<Material>(`${this.baseUrl}/${id}`);
  }

  createMaterial(newMaterial:Material):Observable<Material>{
    return this.http.post<Material>(this.baseUrl, newMaterial, this.httpOptions);
  }

  updateMaterial(id:number, updateMaterial:Material):Observable<Material>{
    return this.http.put<Material>(`${this.baseUrl}/${id}`, updateMaterial, this.httpOptions);
  }

  deleteMaterial(id:number):Observable<Material>{
    return this.http.delete<Material>(`${this.baseUrl}/${id}`);
  }
}
