import { Component } from '@angular/core';
import { Fact } from '../../models/fact.model';

@Component({
  templateUrl: './facts.component.html',
  styleUrls: ['./facts.component.scss']
})
export class FactsComponent {

  public activeFact: Fact | undefined;

  public showFact(fact: Fact | undefined): void {
    this.activeFact = fact;
  }
}
