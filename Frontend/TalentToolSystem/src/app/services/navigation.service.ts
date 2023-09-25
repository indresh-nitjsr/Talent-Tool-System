import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ILocation } from '../model';
import { CandidateComponent } from '../candidate/candidate.component';

@Injectable({
  providedIn: 'root',
})
export class NavigationService {
  logBaseUrl = 'https://localhost:7046/api/Logs/';
  candidateBaseUrl = 'https://localhost:7095/api/Candidate/';
  demandBaseUrl = "https://localhost:7296/api/Demand/";
  constructor(private http: HttpClient) {}

  GetAllCandidateLogs() {
    let url = this.logBaseUrl + 'GetAllCandidateLogs';
    return this.http.get<any[]>(url);
  }

  GetAllDemandLogs() {
    let url = this.logBaseUrl + 'GetAllDemandLogs';
    let data = this.http.get<any[]>(url);
    return data;
  }
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

//***************************** 

  
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
