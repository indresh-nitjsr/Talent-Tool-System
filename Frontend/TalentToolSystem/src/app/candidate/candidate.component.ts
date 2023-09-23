import { Component, OnInit } from '@angular/core';
import { ICandidate } from '../model';
import { NavigationService } from '../services/navigation.service';
import { FormBuilder, FormGroup,FormControl, Validators } from '@angular/forms';
@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css'],
})

export class CandidateComponent implements OnInit {
  dataForm!: FormGroup;
  formdataArray: any = ([] = []);
  serialNo = 1;
  selectedRecord: any = null;

// ******************************************
  view: 'candidate' = 'candidate';
  candidates: ICandidate[] = [];
  candidate: ICandidate = {
  candidateId: 0,
  candidateName: '',
  email: '',
  mobile: '',
  currentCompany: '',
  skillSet: [],
  yearOfExperience: 0,
  location: '',
  ctc: 0,
  ectc: 0,
  noticePeriod: 0,
  employeeID: 0,
  status: '',
};

  constructor(private navigationService: NavigationService,private fb: FormBuilder) {}

  ngOnInit(): void {

    this.dataForm = this.fb.group({
      CandidateName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      Mobile: ['', Validators.required],
      CurrentCompany: ['', Validators.required],
      // SkillSets: ['', Validators.required],
      SkillSets: this.fb.array([]),
      YearsOfExperience: ['', Validators.required],
      CTC: ['', Validators.required],
      ECTC: ['', Validators.required],
      Location: ['', Validators.required],
      EmployeeID: ['', Validators.required],
      Status: ['', Validators.required],
    });
    this.navigationService.GetAllCandidate().subscribe((res: any) => {
      this.candidates = res;
    }); 
  }
  DeleteCandidate(candidate:ICandidate){
    this.navigationService.DeleteCandidate(candidate).subscribe((res:any)=>{
      this.candidates=res;
    }); 
  }
  CreateCandidate(candidate: ICandidate) {
    this.navigationService.CreateCandidate(candidate).subscribe((res: any) => {
        this.candidates=res;
    });   
  }
  UpdateCandidate(candidate:ICandidate){
    this.navigationService.UpdateCandidate(candidate).subscribe((UpdateCandidate:ICandidate)=>{
      this.candidate=UpdateCandidate;
    }); 
  } 
  
}
