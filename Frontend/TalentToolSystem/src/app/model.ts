export interface ICandidate {
  candidateId: number;
  candidateName: string;
  email: string;
  mobile: string;
  currentCompany?: string | null;
  skillSet: string[] | null;
  yearOfExperience: number;
  location: string;
  ctc: number;
  ectc: number;
  noticePeriod: number;
  employeeID: number;
  status: string;
}

export interface IDemand {
  demandId: number,
  demandName: string,
  email: string,
  accountName: string,
  manager: string,
  openPosition: number,
  experience: string,
  maxBudget: DoubleRange,
  noticePeriod: number,
  employeeType: string,
  status: string,
  skills: [],
  location: string
}

export interface ILocation {
  locationId: number,
  city: string,
  state: string;
}
