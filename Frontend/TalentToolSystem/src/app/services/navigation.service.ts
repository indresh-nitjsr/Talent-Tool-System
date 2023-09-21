import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'
import { ILocation } from '../model';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  candidateBaseUrl = "https://localhost:7095/api/Candidate/";
  demandBaseUrl = "https://localhost:7296/api/Demand/";
  constructor(private http: HttpClient) { }

  GetAllCandidate() {
    let url = this.candidateBaseUrl + 'getcandidatelist';
    return this.http.get<any[]>(url);

  }

  GetAllDemand() {
    let url = this.demandBaseUrl + 'getdemandlist';
    return this.http.get<any[]>(url);
  }
}
