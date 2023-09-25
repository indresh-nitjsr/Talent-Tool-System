import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root',
})
export class NavigationService {
  /*************************************************************************
   Base URLs
  **************************************************************************/
  logBaseUrl = 'https://localhost:7046/api/Logs/';
  candidateBaseUrl = 'https://localhost:7095/api/Candidate/';
  demandBaseUrl = "https://localhost:7296/api/Demand/";

  //constructor
  constructor(private http: HttpClient) { }


  /*************************************************************************
   Logs Operations
  **************************************************************************/
  GetAllCandidateLogs() {
    let url = this.logBaseUrl + 'GetAllCandidateLogs';
    let data = this.http.get<any[]>(url);
    return data;
  }

  GetAllDemandLogs() {
    let url = this.logBaseUrl + 'GetAllDemandLogs';
    let data = this.http.get<any[]>(url);
    return data;
  }


  /*************************************************************************
   Candidate Operations
  **************************************************************************/
  GetAllCandidate() {
    let url = this.candidateBaseUrl + 'getcandidatelist';
    return this.http.get<any[]>(url);
  }
  DeleteCandidate(candidate: any) {
    let url = `${this.candidateBaseUrl}deletecandidate?CandidateId=${candidate.candidateId}`;
    return this.http.delete<any>(url);
  }
  CreateCandidate(candidate: any) {
    let url = this.candidateBaseUrl + 'addcandidate';
    return this.http.post<any>(url, candidate, { responseType: 'json' });
  }
  UpdateCandidate(candidate: any) {
    let url = this.candidateBaseUrl + 'updatecandidate';
    return this.http.put(url, candidate, { responseType: 'text' });
  }



  /*************************************************************************
   Demand Operations
  **************************************************************************/
  GetAllDemand() {
    let url = this.demandBaseUrl + 'getdemandlist';
    return this.http.get<any[]>(url);
  }
  DeleteDemand(demand: any) {
    let url = `${this.demandBaseUrl}deletedemand?demandId=${demand.demandId}`;
    return this.http.delete<any>(url);
  }
  CreateDemand(demand: any) {
    let url = this.demandBaseUrl + 'adddemand';
    return this.http.post<any>(url, demand, { responseType: 'json' });
  }
  UpdateDemand(demand: any) {
    let url = this.demandBaseUrl + 'updatedemand';
    return this.http.put(url, demand, { responseType: 'text' });
  }
}
