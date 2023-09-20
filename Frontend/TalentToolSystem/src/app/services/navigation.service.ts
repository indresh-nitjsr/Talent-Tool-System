import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'
import { ILocation } from '../model';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  baseUrl = "https://localhost:7046/api/Location/";
  constructor(private http: HttpClient) { }


  GetAllLocations() {
    let url = this.baseUrl + 'GetAllLocations';
    var data = this.http.get<ILocation[]>(url);
    return data;
  }
}
