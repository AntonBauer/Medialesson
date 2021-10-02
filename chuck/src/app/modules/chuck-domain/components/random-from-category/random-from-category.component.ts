import { FactsService } from './../../services/facts.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Fact } from '../../models/fact.model';

@Component({
  selector: 'chk-random-from-category',
  templateUrl: './random-from-category.component.html',
  styleUrls: ['./random-from-category.component.scss']
})
export class RandomFromCategoryComponent implements OnInit {

  @Output()
  public readonly factLoaded: EventEmitter<Fact> = new EventEmitter<Fact>();

  public categories: string[] | undefined;
  public readonly categoriesForm: FormGroup;

  constructor(
    private readonly factsService: FactsService,
    fb: FormBuilder
  ) {
    this.categoriesForm = fb.group({
      selectedCategory: fb.control('')
    });
  }

  public async ngOnInit(): Promise<void> {
    this.categories = await this.factsService.loadCategories();
  }

  public async loadFromCategory(): Promise<void> {
    const category = this.categoriesForm.get('selectedCategory')?.value;
    const fact = await this.factsService.getRandomFromCategory(category);

    this.factLoaded.emit(fact);
  }
}
