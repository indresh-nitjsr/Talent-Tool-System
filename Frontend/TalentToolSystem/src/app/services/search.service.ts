import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SearchService {
  constructor(private http: HttpClient) {}
    BASE_URL = 'https://localhost:7019/api/search/'

  searchCandidates(queryParams: any): Observable<any[]> {
    const apiUrl = `${this.BASE_URL}SearchCandidates`;
    const params = new HttpParams({ fromObject: queryParams });
    return this.http.get<any[]>(apiUrl, { params });
  }

  searchDemands(queryParams: any): Observable<any[]> {
    const apiUrl = `${this.BASE_URL}SearchDemands`;
    const params = new HttpParams({ fromObject: queryParams });
    return this.http.get<any[]>(apiUrl, { params });
  }
}
