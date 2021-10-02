import { Fact } from './fact.model';

export interface Facts {
  readonly total: number;
  readonly result: Fact[];
}
