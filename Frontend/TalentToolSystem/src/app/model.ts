export interface ICandidate {
  CandidateId: number;
  CandidateName: string;
  Email: string;
  Mobile: string;
  CurrentCompany?: string | null;
  SkillSet: string[] | null;
  YearOfExperience: number;
  Location: string;
  CTC: number;
  ECTC: number;
  NoticePeriod: number;
  EmployeeID: number;
  Status: string;
}

export interface ILocation {
  LocationId: number,
  City: string,
  State: string;
}
