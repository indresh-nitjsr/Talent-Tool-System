import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import * as XLSX from 'xlsx';
import { SearchService } from '../services/search.service';

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

  constructor(private formBuilder: FormBuilder, private http: HttpClient, private searchService: SearchService) {
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
    this.formdataArray = []
  }

  submitCandidateForm() {
    const queryParams: any = { ...this.candidateForm.value };

    for (const key in queryParams) {
      if (queryParams[key] === null || queryParams[key] === '') {
        delete queryParams[key];
      }
    }

    this.searchService.searchCandidates(queryParams).subscribe((response) => {
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

    this.searchService.searchDemands(queryParams).subscribe((response) => {
      this.formdataArray = response;
    });
  }

  exportToExcel() {
    if(this.formdataArray.length === 0){ return; }
    const ws: XLSX.WorkSheet = XLSX.utils.json_to_sheet(this.formdataArray);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'SearchResults');
  
    XLSX.writeFile(wb, 'search-results.xlsx');
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