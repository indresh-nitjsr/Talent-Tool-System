import { Component, OnInit } from '@angular/core';
import { ICandidate, ILocation } from '../model';
import { NavigationService } from '../services/navigation.service';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.css']
})
export class LogComponent implements OnInit {
  locations: ILocation[] = [];

  constructor(private navigationService: NavigationService) { }


  ngOnInit() {
    this.navigationService.GetAllLocations().subscribe((res: ILocation[]) => {
      this.locations = res;
    });
    console.log(this.locations);
  }
  // candidates: ICandidate[] = [
  // ];
  // candidate: ICandidate = {
  //   CandidateId: 1,
  //   CandidateName: 'Indresh Kumar Maurya',
  //   Email: 'imaurya@gmail.com',
  //   Mobile: '7800199452',
  //   CurrentCompany: 'Nexturn',
  //   SkillSet: ["C++", "Python", "Sql Server"],
  //   YearOfExperience: 1,
  //   Location: 'Mirzapur',
  //   CTC: 6,
  //   ECTC: 10,
  //   NoticePeriod: 15,
  //   EmployeeID: 101,
  //   Status: 'Selected',
  // };

  data = this.locations

}
