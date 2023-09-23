import { Component, OnInit } from '@angular/core';
import { ICandidate } from '../model';
import { NavigationService } from '../services/navigation.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css'],
})
export class CandidateComponent implements OnInit {
  // candidate: ICandidate = {
  //   CandidateId: 0,
  //   CandidateName: '',
  //   Email: '',
  //   Mobile: '',
  //   CurrentCompany: '',
  //   SkillSet: [],
  //   YearOfExperience: 0,
  //   Location: '',
  //   CTC: 0,
  //   ECTC: 0,
  //   NoticePeriod: 0,
  //   EmployeeID: 0,
  //   Status: '',
  // };

  dataForm!: FormGroup;
  formdataArray: any = ([] = []);
  serialNo = 1;
  selectedRecord: any = null;

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.dataForm = this.fb.group({
      CandidateName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      Mobile: ['', Validators.required],
      CurrentCompany: ['', Validators.required],
      SkillSets: ['', Validators.required],
      YearsOfExperience: ['', Validators.required],
      CTC: ['', Validators.required],
      ECTC: ['', Validators.required],
      Location: ['', Validators.required],
      MaxNoticePeriod: ['', Validators.required],
      EmployeeID: ['', Validators.required],
      Status: ['', Validators.required],
    });
  }


  submitForm() {
    if (this.dataForm.valid) {
      const formData = this.dataForm.value;
      if (this.selectedRecord) {
        const index = this.formdataArray.findIndex(
          (record: any) => record === this.selectedRecord
        );
        if (index !== -1) {
          this.formdataArray[index] = { ...formData };
          this.selectedRecord = null;
        }
      } else {
        formData.serialNo = this.serialNo++;
        this.formdataArray.push({ ...formData });
      }
      this.dataForm.reset();
    } else {
      console.log('Please fill all the mandatory fields');
    }
  }

  clearForm() {
    this.dataForm.reset();
  }
  editRecord(record: any) {
    this.selectedRecord = record;
    this.dataForm.patchValue({
      CandidateName: this.selectedRecord.CandidateName,
      email: this.selectedRecord.email,
      Mobile: this.selectedRecord.Mobile,
      CurrentCompany: this.selectedRecord.CurrentCompany,
      SkillSets: this.selectedRecord.SkillSets,
      YearsOfExperience: this.selectedRecord.YearsOfExperience,
      CTC: this.selectedRecord.CTC,
      ECTC: this.selectedRecord.ECTC,
      Location: this.selectedRecord.Location,
      MaxNoticePeriod: this.selectedRecord.MaxNoticePeriod,
      EmployeeID: this.selectedRecord.EmployeeID,
      Status: this.selectedRecord.Status,
    });
  }

  deleteRecord(serialNo: number) {
    const index = this.formdataArray.findIndex(
      (record: any) => record.serialNo === serialNo
    );
    if (index !== -1) {
      this.formdataArray.splice(index, 1);
    }
  }
}
