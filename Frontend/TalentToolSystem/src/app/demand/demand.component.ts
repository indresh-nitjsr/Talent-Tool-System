import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-demand',
  templateUrl: './demand.component.html',
  styleUrls: ['./demand.component.css']
})
export class DemandComponent implements OnInit {
  dataForm!: FormGroup;
  formdataArray:any=[]= [];
  serialNo=1;
  selectedRecord:any=null;
  
  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.dataForm = this.fb.group({
      DemandName: ['',Validators.required],
      email: ['',[Validators.required,Validators.email]],
      AccountName: ['',Validators.required],
      Manager: ['',Validators.required],
      OpenPosition: ['',Validators.required],
      SkillSets: ['',Validators.required],
      YearsOfExperience: ['',Validators.required],
      MaxBudget: ['',Validators.required],
      Location: ['',Validators.required],
      MaxNoticePeriod: ['',Validators.required],
      EmploymentType: ['',Validators.required],
      Status: ['',Validators.required]
    });
  }
  submitForm() {
    if(this.dataForm.valid)
    {

      const formData=this.dataForm.value;
      console.log(formData);
          if(this.selectedRecord)
      {
        const index=this.formdataArray.findIndex((record:any)=>record===this.selectedRecord);
        if(index!==-1){
          this.formdataArray[index]={...formData}
          this.selectedRecord=null;
        }
      }
      else
      {
        formData.serialNo=this.serialNo++;
        this.formdataArray.push({...formData});
      }
          console.log(this.formdataArray);
      this.dataForm.reset();
    }
    else
    {
      console.log('Please fill all the mandatory fields');
      
    }
  }

  clearForm() {
    this.dataForm.reset();
  }

  editRecord(record:any) {
    console.log('Editing Record',record);
    this.selectedRecord=record;
    this.dataForm.patchValue({
      DemandName: this.selectedRecord.DemandName,
      email: this.selectedRecord.email,
      AccountName: this.selectedRecord.AccountName,
      Manager: this.selectedRecord.Manager,
      OpenPosition: this.selectedRecord.OpenPosition,
      SkillSets: this.selectedRecord.SkillSets,
      YearsOfExperience: this.selectedRecord.YearsOfExperience,
      MaxBudget: this.selectedRecord.MaxBudget,
      Location: this.selectedRecord.Location,
      MaxNoticePeriod: this.selectedRecord.MaxNoticePeriod,
      EmploymentType: this.selectedRecord.EmploymentType,
      Status: this.selectedRecord.Status
    });
  }

  deleteRecord(serialNo:number) {
    console.log('Deleting Record',serialNo);
    const index=this.formdataArray.findIndex((record:any)=>record.serialNo===serialNo);
    if(index!==-1){
      this.formdataArray.splice(index,1);
    }
  }
  }

