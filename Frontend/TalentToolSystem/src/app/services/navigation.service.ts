import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'
import { ILocation } from '../model';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  logBaseUrl = "https://localhost:7046/api/Logs/"
  // candidateBaseUrl = "https://localhost:7095/api/Candidate/";
  // demandBaseUrl = "https://localhost:7296/api/Demand/";
  constructor(private http: HttpClient) { }

  GetAllCandidateLogs() {
    let url = this.logBaseUrl + "GetAllCandidateLogs"
    return this.http.get<any[]>(url);
  }

  GetAllDemandLogs() {
    let url = this.logBaseUrl + "GetAllDemandLogs"
    let data = this.http.get<any[]>(url);
    return data;
  }
  // GetAllCandidate() {
  //   let url = this.candidateBaseUrl + 'getcandidatelist';
  //   return this.http.get<any[]>(url);

  // }

  // GetAllDemand() {
  //   let url = this.demandBaseUrl + 'getdemandlist';
  //   return this.http.get<any[]>(url);
  // }
}
