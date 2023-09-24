import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent {
  isCandidateSearch: boolean = true;
  candidateForm: any = {
    Account: '',
    CandidateName: '',
    Manager: '',
    Status: '',
    Location:'',
    ReferralId: null
  };
  demandForm: any = {
    Account: '',
    Demand: '',
    Manager: '',
    Status: '',
    Location: '',
    EmployeeType: '',
  };

  candidateDataArray: any[] = [];
  demandDataArray: any[] = []; 
  formdataArray: any[] = [];

  constructor(private formBuilder: FormBuilder, private http: HttpClient) {
      this.candidateForm = this.formBuilder.group({
        Account: [''],
        Manager: [''],
        CandidateName: [''],
        Location: [''],
        ReferralId: [null],
        Status: [''],
      });
      this.demandForm = this.formBuilder.group({
        Account: [''],
        Demand: [''],
        Manager: [''],
        Status: [''],
        Location: [''],
        EmployeeType: [''],
      });
  }

  toggleSearch() {
    this.isCandidateSearch = !this.isCandidateSearch;
  }

  submitCandidateForm() {
    const queryParams: any = { ...this.candidateForm.value };

    for (const key in queryParams) {
      if (queryParams[key] === null || queryParams[key] === '') {
        delete queryParams[key];
      }
    }

    const apiUrl = `https://localhost:7019/api/search/SearchCandidates`;

    this.http.get<any[]>(apiUrl, { params: queryParams }).subscribe((response) => {
      this.formdataArray = response;
    });

  }

  submitDemandForm() {
    const queryParams: any = { ...this.demandForm.value };
    for (const key in queryParams) {
      if (queryParams[key] === null || queryParams[key] === '') {
        delete queryParams[key];
      }
    }

    const apiUrl = `https://localhost:7019/api/search/SearchDemands`;

    this.http.get<any[]>(apiUrl, { params: queryParams }).subscribe((response) => {
      this.formdataArray = response;
    });
  }

  clearForm() {
    if (this.isCandidateSearch) {
      this.candidateForm.reset();
    } else {
      this.demandForm.reset();
    }
    this.formdataArray = [];
  }
}