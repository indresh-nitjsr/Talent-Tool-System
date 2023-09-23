import { Component, OnInit } from '@angular/core';
import { ICandidate, IDemand, ILocation } from '../model';
import { NavigationService } from '../services/navigation.service';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.css']
})
export class LogComponent implements OnInit {
  view: 'candidate' | 'demand' = 'demand';
  candidates: ICandidate[] = [
    {
      candidateId: 1,
      name: 'Indresh Kumar Maurya',
      email: 'indresh@gmail.com',
      mobile: '7800199454',
      currentCompany: 'Nexturn',
      skillSet: "C, C++,Python",
      yearOfExperience: 1,
      location: 'Mirzapur',
      ctc: 10,
      ectc: 10,
      noticePeriod: 15,
      referralId: 20220101,
      status: 'Selected',
      account: "Saleforce",
      manager: "Gunjan"
    },
    {
      candidateId: 2,
      name: 'Shobhit Singh',
      email: 'shobhit@gmail.com',
      mobile: '9669047175',
      currentCompany: 'Nexturn',
      skillSet: "C, C++,Python",
      yearOfExperience: 1,
      location: 'Patna',
      ctc: 10,
      ectc: 10,
      noticePeriod: 15,
      referralId: 20220102,
      status: 'Selected',
      account: "Amazon",
      manager: "Bhaskar"
    },
    {
      candidateId: 3,
      name: 'Abuzar Nasim',
      email: 'abuzar@gmail.com',
      mobile: '7878787878',
      currentCompany: 'Nexturn',
      skillSet: "C, C++,Python",
      yearOfExperience: 1,
      location: 'Ranchi',
      ctc: 10,
      ectc: 10,
      noticePeriod: 15,
      referralId: 20220103,
      status: 'Selected',
      account: "Salesforce",
      manager: "Gunjan"
    },
    {
      candidateId: 4,
      name: 'Sahaja',
      email: 'sahaja@gmail.com',
      mobile: '7800941956',
      currentCompany: 'Nexturn',
      skillSet: "C, C++, Python",
      yearOfExperience: 1,
      location: 'Jharkhand',
      ctc: 10,
      ectc: 10,
      noticePeriod: 15,
      referralId: 101,
      status: 'Selected',
      account: "Flipkart",
      manager: "Gunjan"
    }
  ];
  demands: IDemand[] = [
    {
      demandId: 1,
      name: 'Python Developer',
      email: 'amazon@nexturn.com',
      accountName: 'Amazon',
      manager: "Gunjan",
      openPosition: 3,
      experience: '1',
      noticePeriod: 2,
      employeeType: "FTE",
      status: "Active",
      skills: [],
      location: "Hyderabad"
    },
    {
      demandId: 2,
      name: 'Java Developer',
      email: 'slaesforce@nexturn.com',
      accountName: 'Salesforce',
      manager: "Gunjan",
      openPosition: 3,
      experience: '1',
      noticePeriod: 2,
      employeeType: "FTE",
      status: "Active",
      skills: [],
      location: "Bengaluru"
    },
    {
      demandId: 3,
      name: '.Net Developer',
      email: 'amazon@nexturn.com',
      accountName: 'Amazon',
      manager: "Gunjan",
      openPosition: 3,
      experience: '1',
      noticePeriod: 2,
      employeeType: "FTE",
      status: "Active",
      skills: [],
      location: "Hyderabad"
    },
    {
      demandId: 4,
      name: 'Frontend Developer',
      email: 'flipkart@nexturn.com',
      accountName: 'Flipkart',
      manager: "Gunjan",
      openPosition: 3,
      experience: '1',
      noticePeriod: 2,
      employeeType: "FTE",
      status: "Active",
      skills: [],
      location: "Noida"
    }
  ];

  isEmpty = true;
  constructor(private navigationService: NavigationService) { }

  message = "This is a dummy Data";
  isCandidateNull = true;
  isDemandNull = true
  ngOnInit(): void {
    this.navigationService.GetAllCandidateLogs().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.isCandidateNull = false;
        this.candidates = res;
      }
    });

    this.navigationService.GetAllDemandLogs().subscribe((res: any) => {
      if (res && res.length > 0) {
        this.isDemandNull = false;
        this.demands = res;
      }
    });
  }
}
