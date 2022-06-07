import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
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

  readMaterialsBySearch(title:string,location:string, genre:string,author:string):Observable<Material[]>{
    let queryOptions = new HttpParams();
    queryOptions = queryOptions.append("searchTitle",title);
    queryOptions = queryOptions.append("location",location);
    queryOptions = queryOptions.append("genre",genre);
    queryOptions = queryOptions.append("author",author);
    console.log(`Data er modtaget, title: ${title}, lokation: ${location}, genre: ${genre}, forfatter: ${author}`);

    return this.http.get<Material[]>(this.baseUrl, {params:queryOptions});
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
