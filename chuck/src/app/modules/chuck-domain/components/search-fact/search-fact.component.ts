import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { Fact } from '../../models/fact.model';
import { FactsService } from '../../services/facts.service';

@Component({
  selector: 'chk-search-fact',
  templateUrl: './search-fact.component.html',
  styleUrls: ['./search-fact.component.scss']
})
export class SearchFactComponent {

  @Output()
  public readonly factLoaded: EventEmitter<Fact | undefined> = new EventEmitter<Fact | undefined>();

  public readonly searchForm: FormGroup;

  constructor(
    private readonly factsService: FactsService,
    fb: FormBuilder
  ) {
    this.searchForm = fb.group({
      searchQuery: fb.control('')
    });
  }

  public async findFact(): Promise<void> {
    const query = this.searchForm.get('searchQuery')?.value;
    const fact = await this.factsService.findFact(query);

    this.factLoaded.emit(fact);
  }
}
