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
      name: 'Indresh Kumar',
      email: 'indresh@gmail.com',
      mobile: '7878787878',
      currentCompany: 'Nexturn',
      skillSet: ["C", "C++", "Python"],
      yearOfExperience: 1,
      location: 'Mirzapur',
      ctc: 10,
      ectc: 10,
      noticePeriod: 15,
      employeeID: 101,
      status: 'Selected',
    },
    {
      candidateId: 2,
      name: 'Shobhit Kumar',
      email: 'shobhit@gmail.com',
      mobile: '7878787878',
      currentCompany: 'Nexturn',
      skillSet: ["C", "C++", "Python"],
      yearOfExperience: 1,
      location: 'Patna',
      ctc: 10,
      ectc: 10,
      noticePeriod: 15,
      employeeID: 101,
      status: 'Selected',
    },
    {
      candidateId: 3,
      name: 'Abuzar Nasim',
      email: 'abuzar@gmail.com',
      mobile: '7878787878',
      currentCompany: 'Nexturn',
      skillSet: ["C", "C++", "Python"],
      yearOfExperience: 1,
      location: 'Ranchi',
      ctc: 10,
      ectc: 10,
      noticePeriod: 15,
      employeeID: 101,
      status: 'Selected',
    },
    {
      candidateId: 4,
      name: 'Sahaja',
      email: 'sahaja@gmail.com',
      mobile: '7878787878',
      currentCompany: 'Nexturn',
      skillSet: ["C", "C++", "Python"],
      yearOfExperience: 1,
      location: 'Jh',
      ctc: 10,
      ectc: 10,
      noticePeriod: 15,
      employeeID: 101,
      status: 'Selected',
    }
  ];
  demands: IDemand[] = [
    {
      demandId: 1,
      name: 'Python Developer',
      email: 'abc@nexturn.com',
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
      demandId: 1,
      name: 'Python Developer',
      email: 'abc@nexturn.com',
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
      demandId: 1,
      name: 'Python Developer',
      email: 'abc@nexturn.com',
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
      demandId: 1,
      name: 'Python Developer',
      email: 'abc@nexturn.com',
      accountName: 'Amazon',
      manager: "Gunjan",
      openPosition: 3,
      experience: '1',
      noticePeriod: 2,
      employeeType: "FTE",
      status: "Active",
      skills: [],
      location: "Hyderabad"
    }
  ];

  isEmpty = true;
  constructor(private navigationService: NavigationService) { }

  ngOnInit(): void {
    this.navigationService.GetAllCandidateLogs().subscribe((res: any) => {
      this.candidates = [];
      console.log(res);

      this.candidates = res;
    });

    this.navigationService.GetAllDemandLogs().subscribe((res: any) => {
      this.demands = [];
      this.demands = res;
    });
  }
}
