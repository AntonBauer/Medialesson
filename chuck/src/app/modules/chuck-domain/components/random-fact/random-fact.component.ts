import { Component, EventEmitter, OnInit, Output } from '@angular/core';

import { FactsService } from './../../services/facts.service';
import { Fact } from '../../models/fact.model';

@Component({
  selector: 'chk-random-fact',
  templateUrl: './random-fact.component.html',
  styleUrls: ['./random-fact.component.scss']
})
export class RandomFactComponent {

  @Output()
  public readonly factLoaded: EventEmitter<Fact> = new EventEmitter<Fact>();

  constructor(private readonly factsService: FactsService) { }

  public async loadRandom(): Promise<void> {
    const fact = await this.factsService.getRandomFact();
    this.factLoaded.emit(fact);
  }
}
