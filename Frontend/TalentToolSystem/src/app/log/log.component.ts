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
  candidates: ICandidate[] = [];
  demands: IDemand[] = [];
  constructor(private navigationService: NavigationService) { }

  ngOnInit(): void {
    this.navigationService.GetAllCandidateLogs().subscribe((res: any) => {
      // console.log(res);
      this.candidates = res;
    });

    this.navigationService.GetAllDemandLogs().subscribe((res: any) => {
      this.demands = res;
      console.log(res);

    });
  }
}
